using Huawei.E3372.Manager.Logic.Entities;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.Sms;
using Microsoft.EntityFrameworkCore;

namespace Huawei.E3372.Manager.Logic.Modems;

public class SmsService(
    IModemClient modemClient,
    ApplicationDbContext dbContext)
    : ISmsService
{
    public async Task<ServiceDataResult<ModemSms[]>> PollIncomingAsync(
        Modem modem,
        bool setAsRead = true,
        bool delete = false,
        CancellationToken cancellationToken = default)
    {
        var request = new SmsListRequest()
        {
            PageIndex = 1,
            ReadCount = 50,
            BoxType = 1,
            SortType = 0,
            Ascending = false,
            UnreadPreferred = false,
        };

        return await PollAsync(modem, request, setAsRead, delete, cancellationToken);
    }

    public async Task<ServiceDataResult<ModemSms[]>> PollOutgoingAsync(
        Modem modem,
        bool delete = false,
        CancellationToken cancellationToken = default)
    {
        var request = new SmsListRequest()
        {
            PageIndex = 1,
            ReadCount = 50,
            BoxType = 2,
            SortType = 0,
            Ascending = false,
            UnreadPreferred = false,
        };

        return await PollAsync(modem, request, setAsRead: false, delete, cancellationToken);
    }

    public async Task<ServiceDataResult<ModemSms[]>> PollDraftAsync(
        Modem modem,
        bool delete = false,
        CancellationToken cancellationToken = default)
    {
        var request = new SmsListRequest()
        {
            PageIndex = 1,
            ReadCount = 50,
            BoxType = 3,
            SortType = 0,
            Ascending = false,
            UnreadPreferred = false,
        };

        return await PollAsync(modem, request, setAsRead: false, delete, cancellationToken);
    }

    public async Task<ServiceResult> SendAsync(
        Modem modem,
        IEnumerable<string> phones,
        string content,
        CancellationToken cancellationToken = default)
    {
        var request = new SendSmsRequest()
        {
            Index = -1,
            Phones = new SendSmsPhones() { Phones = phones.ToArray() },
            Content = content,
            Length = content.Length,
            Reserved = true,
            Date = DateTime.UtcNow.ToString(),
        };

        try
        {
            await modemClient.PostAsync<SendSmsRequest, SendSmsResponse>(modem.Uri, request, cancellationToken);
            return ServiceResult.Success();
        }
        catch (HttpRequestException ex)
        {
            return ServiceResult.Failure(ServiceResultErrorCode.RemoteNotFound, ex.Message);
        }
    }

    public async Task<ServiceResult> MarkAsReadAsync(
        Modem modem,
        ModemSms sms,
        CancellationToken cancellationToken = default)
    {
        var request = new SetReadRequest()
        {
            Index = sms.Index,
        };

        try
        {
            await modemClient.PostAsync<SetReadRequest, SetReadResponse>(modem.Uri, request, cancellationToken);
            return ServiceResult.Success();
        }
        catch (HttpRequestException ex)
        {
            return ServiceResult.Failure(ServiceResultErrorCode.RemoteNotFound, ex.Message);
        }
    }

    public async Task<ServiceResult> DeleteAsync(
        Modem modem,
        ModemSms sms,
        CancellationToken cancellationToken = default)
    {
        var request = new DeleteSmsRequest()
        {
            Index = sms.Index,
        };

        try
        {
            await modemClient.PostAsync<DeleteSmsRequest, DeleteSmsResponse>(modem.Uri, request, cancellationToken);
            return ServiceResult.Success();
        }
        catch (HttpRequestException ex)
        {
            return ServiceResult.Failure(ServiceResultErrorCode.RemoteNotFound, ex.Message);
        }
    }

    internal async Task<ServiceDataResult<ModemSms[]>> PollAsync(
        Modem modem,
        SmsListRequest request,
        bool setAsRead = true,
        bool delete = false,
        CancellationToken cancellationToken = default)
    {
        IEnumerable<SmsListMessage> smsFromModem;

        try
        {
            var response = await modemClient.PostAsync<SmsListRequest, SmsListResponse>(modem.Uri, request, cancellationToken);
            smsFromModem = response.Messages.Messages ?? Enumerable.Empty<SmsListMessage>();
        }
        catch (HttpRequestException ex)
        {
            return ServiceDataResult<ModemSms[]>.Failure(ServiceResultErrorCode.RemoteNotFound, ex.Message);
        }

        var smsIndexes = smsFromModem.Select(sms => sms.Index).ToHashSet();

        var existingSmsInDbByIndex = dbContext.ModemSms.AsNoTracking()
            .Where(s => s.ModemId == modem.Id)
            .Where(s => smsIndexes.Contains(s.Index))
            .ToDictionary(s => s.Index, s => s);

        var newSms = smsFromModem
            .Where(s => !existingSmsInDbByIndex.ContainsKey(s.Index))
            .Select(s => new ModemSms(modem, s) { Id = Guid.NewGuid() })
            .ToArray();
        await dbContext.ModemSms.AddRangeAsync(newSms, cancellationToken);

        var udpatedSms = smsFromModem
            .Where(s => existingSmsInDbByIndex.ContainsKey(s.Index))
            .Select(s => new ModemSms(modem, s) { Id = existingSmsInDbByIndex[s.Index].Id })
            .Where(s => s != existingSmsInDbByIndex[s.Index])
            .ToArray();
        dbContext.ModemSms.UpdateRange(udpatedSms);

        await dbContext.SaveChangesAsync(cancellationToken);

        if (request.BoxType == 1 && setAsRead && !delete)
        {
            var setReadRequests = smsFromModem
                .Where(s => s.Status == 0)
                .Select(s => new SetReadRequest() { Index = s.Index })
                .ToArray();

            foreach (var setReadRequest in setReadRequests)
                await modemClient.PostAsync<SetReadRequest, SetReadResponse>(modem.Uri, setReadRequest, cancellationToken);
        }

        if (delete)
        {
            var smsDeleteRequests = smsFromModem
                .Select(s => new DeleteSmsRequest() { Index = s.Index })
                .ToArray();

            foreach (var smsDeleteRequest in smsDeleteRequests)
                await modemClient.PostAsync<DeleteSmsRequest, DeleteSmsResponse>(modem.Uri, smsDeleteRequest, cancellationToken);
        }

        return ServiceDataResult<ModemSms[]>.Success([.. newSms, .. udpatedSms]);
    }
}

public interface ISmsService
{
    public Task<ServiceDataResult<ModemSms[]>> PollIncomingAsync(
        Modem modem,
        bool setAsRead = true,
        bool delete = false,
        CancellationToken cancellationToken = default);

    public Task<ServiceDataResult<ModemSms[]>> PollOutgoingAsync(
        Modem modem,
        bool delete = false,
        CancellationToken cancellationToken = default);

    public Task<ServiceDataResult<ModemSms[]>> PollDraftAsync(
        Modem modem,
        bool delete = false,
        CancellationToken cancellationToken = default);

    public Task<ServiceResult> SendAsync(
        Modem modem,
        IEnumerable<string> phones,
        string content,
        CancellationToken cancellationToken = default);

    public Task<ServiceResult> MarkAsReadAsync(
        Modem modem,
        ModemSms sms,
        CancellationToken cancellationToken = default);

    public Task<ServiceResult> DeleteAsync(
        Modem modem,
        ModemSms sms,
        CancellationToken cancellationToken = default);
}