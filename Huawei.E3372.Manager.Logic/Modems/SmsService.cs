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
        var rawSmsFromModem = new List<SmsListMessage>();
        var rawSmsBatch = Enumerable.Empty<SmsListMessage>();

        request.PageIndex = 0;
        request.ReadCount = 50;

        try
        {
            do
            {
                request.PageIndex++;

                var response = await modemClient.PostAsync<SmsListRequest, SmsListResponse>(modem, request, cancellationToken);
                rawSmsBatch = response.Messages.Messages ?? Enumerable.Empty<SmsListMessage>();
                rawSmsFromModem.AddRange(rawSmsBatch);
            } while (rawSmsBatch.Count() == request.ReadCount);
        }
        catch (HttpRequestException ex)
        {
            return ServiceDataResult<ModemSms[]>.Failure(ServiceResultErrorCode.RemoteNotFound, ex.Message);
        }

        if (rawSmsFromModem.Count == 0)
            return new ServiceDataResult<ModemSms[]>([]);

        var smsFromModem = rawSmsFromModem
            .Select(sms => MapToSms(modem, sms))
            .ToDictionary(sms => new Tuple<int, DateTimeOffset>(sms.Index, sms.CreatedAt));

        var existingSmsInDb = await dbContext.ModemSms.AsNoTracking()
            .Where(sms => sms.ModemId == modem.Id)
            //.Where(sms => smsFromModem.ContainsKey(new Tuple<int, DateTimeOffset>(sms.Index, sms.CreatedAt)))
            .ToDictionaryAsync(sms => new Tuple<int, DateTimeOffset>(sms.Index, sms.CreatedAt), cancellationToken);

        var newSms = smsFromModem
            .Where(kvp => !existingSmsInDb.ContainsKey(kvp.Key))
            .Select(kvp => kvp.Value)
            .ToArray();
        await dbContext.ModemSms.AddRangeAsync(newSms, cancellationToken);

        var udpatedSms = smsFromModem
            .Where(kvp => existingSmsInDb.ContainsKey(kvp.Key) && existingSmsInDb[kvp.Key] != kvp.Value)
            .Select(kvp => kvp.Value)
            .ToArray();
        dbContext.ModemSms.UpdateRange(udpatedSms);

        await dbContext.SaveChangesAsync(cancellationToken);

        if (delete)
        {
            var smsDeleteRequests = smsFromModem
                .Select(kvp => new DeleteSmsRequest() { Index = kvp.Value.Index })
                .ToArray();

            // TODO: Add error handling & logging to mute exceptions
            foreach (var smsDeleteRequest in smsDeleteRequests)
                await modemClient.PostAsync<DeleteSmsRequest, DeleteSmsResponse>(modem, smsDeleteRequest, cancellationToken);
        }
        else if (request.BoxType == 1 && setAsRead)
        {
            var setReadRequests = smsFromModem
                .Where(kvp => kvp.Value.Status == ModemSmsStatus.Unread)
                .Select(kvp => new SetReadRequest() { Index = kvp.Value.Index })
                .ToArray();

            // TODO: Add error handling & logging to mute exceptions
            foreach (var setReadRequest in setReadRequests)
                await modemClient.PostAsync<SetReadRequest, SetReadResponse>(modem, setReadRequest, cancellationToken);
        }

        return ServiceDataResult<ModemSms[]>.Success([.. newSms, .. udpatedSms]);
    }

    internal static ModemSms MapToSms(Modem modem, SmsListMessage smsMesssage)
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