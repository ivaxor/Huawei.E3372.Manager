using Huawei.E3372.Manager.Logic.Entities;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.Sms;
using Microsoft.EntityFrameworkCore;
using System.Web;

namespace Huawei.E3372.Manager.Logic.Modems;

public class SmsService(
    IModemClient modemClient,
    ApplicationDbContext dbContext)
    : ISmsService
{
    public async Task<ServiceDataResult<ModemSms[]>> PollIncomingAsync(
        Modem modem,
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

        return await PollAsync(
            modem,
            request,
            modem.Settings!.PollIncomingSmsThenSetAsRead,
            modem.Settings!.PollIncomingSmsThenDelete,
            cancellationToken);
    }

    public async Task<ServiceDataResult<ModemSms[]>> PollOutgoingAsync(
        Modem modem,
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

        return await PollAsync(
            modem,
            request,
            setAsRead: false,
            modem.Settings!.PollOutgoingSmsThenDelete,
            cancellationToken);
    }

    public async Task<ServiceDataResult<ModemSms[]>> PollDraftAsync(
        Modem modem,
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

        return await PollAsync(
            modem,
            request,
            setAsRead: false,
            modem.Settings!.PollDraftSmsThenDelete,
            cancellationToken);
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
            Date = DateTimeOffset.UtcNow.ToString(),
        };

        try
        {
            await modemClient.PostAsync<SendSmsRequest, SendSmsResponse>(modem, request, cancellationToken);
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
            await modemClient.PostAsync<SetReadRequest, SetReadResponse>(modem, request, cancellationToken);
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
            await modemClient.PostAsync<DeleteSmsRequest, DeleteSmsResponse>(modem, request, cancellationToken);
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
            var response = await modemClient.PostAsync<SmsListRequest, SmsListResponse>(modem, request, cancellationToken);
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
            .Select(s => MapToSms(Guid.NewGuid(), modem, s))
            .ToArray();
        await dbContext.ModemSms.AddRangeAsync(newSms, cancellationToken);

        var udpatedSms = smsFromModem
            .Where(s => existingSmsInDbByIndex.ContainsKey(s.Index))
            .Select(s => MapToSms(existingSmsInDbByIndex[s.Index].Id, modem, s))
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
                await modemClient.PostAsync<SetReadRequest, SetReadResponse>(modem, setReadRequest, cancellationToken);
        }

        if (delete)
        {
            var smsDeleteRequests = smsFromModem
                .Select(s => new DeleteSmsRequest() { Index = s.Index })
                .ToArray();

            foreach (var smsDeleteRequest in smsDeleteRequests)
                await modemClient.PostAsync<DeleteSmsRequest, DeleteSmsResponse>(modem, smsDeleteRequest, cancellationToken);
        }

        return ServiceDataResult<ModemSms[]>.Success([.. newSms, .. udpatedSms]);
    }

    internal ModemSms MapToSms(Guid id, Modem modem, SmsListMessage smsMesssage)
    {
        var sms = new ModemSms()
        {
            ModemId = modem.Id,

            Index = smsMesssage.Index,
            Status = smsMesssage.Status switch
            {
                0 => ModemSmsStatus.Unread,
                1 => ModemSmsStatus.Read,
                2 => ModemSmsStatus.Failed,
                3 => ModemSmsStatus.Delivered,
                _ => throw new NotImplementedException(),
            },
            Content = HttpUtility.HtmlDecode(smsMesssage.Content),
            Priority = smsMesssage.Priority,

            CreatedAt = new DateTimeOffset(DateTime.Parse(smsMesssage.Date), modem.Status!.TimeZoneInfo?.BaseUtcOffset ?? TimeSpan.Zero),
            LastUpdatedAt = DateTimeOffset.UtcNow,
        };

        sms.FromPhoneNumber = sms.Status switch
        {
            ModemSmsStatus.Unread => smsMesssage.Phones,
            ModemSmsStatus.Read => smsMesssage.Phones,
            ModemSmsStatus.Failed => modem.Status?.PhoneNumber,
            ModemSmsStatus.Delivered => modem.Status?.PhoneNumber,
            _ => throw new NotImplementedException(),
        };

        sms.ToPhoneNumbers = sms.Status switch
        {
            ModemSmsStatus.Unread => modem.Status?.PhoneNumber,
            ModemSmsStatus.Read => modem.Status?.PhoneNumber,
            ModemSmsStatus.Failed => smsMesssage.Phones,
            ModemSmsStatus.Delivered => smsMesssage.Phones,
            _ => throw new NotImplementedException(),
        };

        return sms;
    }
}

public interface ISmsService
{
    public Task<ServiceDataResult<ModemSms[]>> PollIncomingAsync(
        Modem modem,
        CancellationToken cancellationToken = default);

    public Task<ServiceDataResult<ModemSms[]>> PollOutgoingAsync(
        Modem modem,
        CancellationToken cancellationToken = default);

    public Task<ServiceDataResult<ModemSms[]>> PollDraftAsync(
        Modem modem,
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