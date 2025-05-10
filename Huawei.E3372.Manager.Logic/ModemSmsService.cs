using Huawei.E3372.Manager.Logic.Entities;
using Huawei.E3372.Manager.Logic.Modems;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.Sms;
using Microsoft.EntityFrameworkCore;

namespace Huawei.E3372.Manager.Logic;

public class ModemSmsService(
    IModemClient modemClient,
    ApplicationDbContext dbContext)
{
    public async Task<ServiceResult<ModemSms[]>> PollIncomingAsync(
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

    public async Task<ServiceResult<ModemSms[]>> PollOutgoingAsync(
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

    internal async Task<ServiceResult<ModemSms[]>> PollAsync(
        Modem modem,
        SmsListRequest request,
        bool setAsRead = true,
        bool delete = false,
        CancellationToken cancellationToken = default)
    {
        var smsFromModem = Enumerable.Empty<SmsListMessage>();

        try
        {
            var response = await modemClient.PostAsync<SmsListRequest, SmsListResponse>(modem.Host, request, cancellationToken);
            smsFromModem = response.Messages.Messages;
        }
        catch (HttpRequestException)
        {
            return ServiceResult<ModemSms[]>.Failure(ServiceResultErrorCode.RemoteNotFound);
        }

        var smsIndexes = smsFromModem.Select(sms => sms.Index).ToHashSet();

        var existingSmsInDbByIndex = dbContext.ModemSms.AsNoTracking()
            .Where(sms => sms.ModemId == modem.Id)
            .Where(sms => smsIndexes.Contains(sms.Index))
            .ToDictionary(sms => sms.Index, sms => sms);

        var newSms = smsFromModem
            .Where(sms => !existingSmsInDbByIndex.ContainsKey(sms.Index))
            .Select(sms => new ModemSms(modem, sms))
            .ToArray();
        await dbContext.ModemSms.AddRangeAsync(newSms, cancellationToken);

        var udpatedSms = smsFromModem
            .Where(sms => existingSmsInDbByIndex.ContainsKey(sms.Index))
            .Select(sms => new ModemSms(modem, sms) with { Id = existingSmsInDbByIndex[sms.Index].Id })
            .Where(sms => sms != existingSmsInDbByIndex[sms.Index])
            .ToArray();
        dbContext.ModemSms.UpdateRange(udpatedSms);

        await dbContext.SaveChangesAsync(cancellationToken);

        if (request.BoxType == 1 && setAsRead && !delete)
        {
            var setReadRequests = smsFromModem
                .Where(sms => sms.Status == 0)
                .Select(sms => new SetReadRequest() { Index = sms.Index })
                .ToArray();

            foreach (var setReadRequest in setReadRequests)
                await modemClient.PostAsync<SetReadRequest, SetReadResponse>(modem.Host, setReadRequest, cancellationToken);
        }

        if (delete)
        {
            var smsDeleteRequests = smsFromModem
                .Select(sms => new DeleteSmsRequest() { Index = sms.Index })
                .ToArray();

            foreach (var smsDeleteRequest in smsDeleteRequests)
                await modemClient.PostAsync<DeleteSmsRequest, DeleteSmsResponse>(modem.Host, smsDeleteRequest, cancellationToken);
        }

        return ServiceResult<ModemSms[]>.Success(newSms.Concat(udpatedSms).ToArray());
    }
}