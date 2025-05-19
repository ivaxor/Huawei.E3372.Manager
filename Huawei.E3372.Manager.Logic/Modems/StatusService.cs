using Huawei.E3372.Manager.Logic.Entities;
using Huawei.E3372.Manager.Logic.Modems.Models;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.Device;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.Monitoring;
using Microsoft.EntityFrameworkCore;
using System.Web;

namespace Huawei.E3372.Manager.Logic.Modems;

public class StatusService(
    IModemClient modemClient,
    ApplicationDbContext dbContext)
    : IStatusService
{
    public async Task<ServiceDataResult<ModemStatus>> PollAsync(
        Modem modem,
        CancellationToken cancellationToken = default)
    {
        InformationResponse informationResponse;
        OperatorResponse operatorResponse;
        SignalResponse signalResponse;
        CheckNotificationResponse checkNotificationResponse;
        try
        {
            (informationResponse, operatorResponse, signalResponse, checkNotificationResponse) = await ConcurrentTasks.AsParallel(
                modemClient.GetAsync<InformationResponse>(modem, cancellationToken),
                modemClient.GetAsync<OperatorResponse>(modem, cancellationToken),
                modemClient.GetAsync<SignalResponse>(modem, cancellationToken),
                modemClient.GetAsync<CheckNotificationResponse>(modem, cancellationToken));
        }
        catch (HttpRequestException ex)
        {
            return ServiceDataResult<ModemStatus>.Failure(ServiceResultErrorCode.RemoteNotFound, ex.Message);
        }

        var modemStatus = await dbContext.ModemStatuses.SingleOrDefaultAsync(s => s.ModemId == modem.Id, cancellationToken);
        if (modemStatus == null)
        {
            modemStatus = new ModemStatus() { Id = Guid.NewGuid(), ModemId = modem.Id };
            await dbContext.AddAsync(modemStatus, cancellationToken);
        }

        modemStatus.IMSI = informationResponse.Imsi;
        modemStatus.ICCID = informationResponse.Iccid;

        modemStatus.OperatorName = HttpUtility.HtmlDecode(operatorResponse.FullName);
        modemStatus.OperatorNumber = operatorResponse.Numeric;

        modemStatus.CID = signalResponse.CellId;
        modemStatus.RSRQ = HttpUtility.HtmlDecode(signalResponse.Rsrq);
        modemStatus.RSRP = HttpUtility.HtmlDecode(signalResponse.Rsrp);
        modemStatus.RSSI = HttpUtility.HtmlDecode(signalResponse.Rssi);
        modemStatus.SINR = HttpUtility.HtmlDecode(signalResponse.Sinr);

        modemStatus.SmsStorageFull = checkNotificationResponse.SmsStorageFull;

        modemStatus.LastUpdatedAt = DateTimeOffset.UtcNow;

        await dbContext.SaveChangesAsync(cancellationToken);

        return ServiceDataResult<ModemStatus>.Success(modemStatus);
    }
}

public interface IStatusService
{
    public Task<ServiceDataResult<ModemStatus>> PollAsync(
        Modem modem,
        CancellationToken cancellationToken = default);
}