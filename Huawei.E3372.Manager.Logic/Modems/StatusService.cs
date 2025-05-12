using Huawei.E3372.Manager.Logic.Entities;
using Huawei.E3372.Manager.Logic.Modems.Models;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.Device;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.Monitoring;
using Microsoft.EntityFrameworkCore;

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
                modemClient.GetAsync<InformationResponse>(modem.Uri, cancellationToken),
                modemClient.GetAsync<OperatorResponse>(modem.Uri, cancellationToken),
                modemClient.GetAsync<SignalResponse>(modem.Uri, cancellationToken),
                modemClient.GetAsync<CheckNotificationResponse>(modem.Uri, cancellationToken));
        }
        catch (HttpRequestException ex)
        {
            return ServiceDataResult<ModemStatus>.Failure(ServiceResultErrorCode.RemoteNotFound, ex.Message);
        }

        var modemStatus = await dbContext.ModemStatuses.AsNoTracking().SingleOrDefaultAsync(s => s.ModemId == modem.Id, cancellationToken);
        if (modemStatus == null)
        {
            modemStatus = new ModemStatus(modem, informationResponse, operatorResponse, signalResponse, checkNotificationResponse)
            {
                Id = Guid.NewGuid(),
            };
            await dbContext.AddAsync(modemStatus, cancellationToken);
        }
        else
        {
            modemStatus = new ModemStatus(modem, informationResponse, operatorResponse, signalResponse, checkNotificationResponse)
            {
                Id = modemStatus.Id,
            };
            dbContext.Update(modemStatus);
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        return ServiceDataResult<ModemStatus>.Success(modemStatus);
    }

    public async Task<ServiceDataResult<ModemStatus>> SetPhoneNumberAsync(
        Modem modem,
        string phoneNumber,
        CancellationToken cancellationToken = default)
    {
        var modemStatus = await dbContext.ModemStatuses.SingleOrDefaultAsync(s => s.ModemId == modem.Id, cancellationToken);
        if (modemStatus == null)
            return ServiceDataResult<ModemStatus>.Failure(ServiceResultErrorCode.LocalNotFound);

        modemStatus.PhoneNumber = phoneNumber;
        await dbContext.SaveChangesAsync(cancellationToken);

        return ServiceDataResult<ModemStatus>.Success(modemStatus);
    }
}

public interface IStatusService
{
    public Task<ServiceDataResult<ModemStatus>> PollAsync(
        Modem modem,
        CancellationToken cancellationToken = default);

    public Task<ServiceDataResult<ModemStatus>> SetPhoneNumberAsync(
        Modem modem,
        string phoneNumber,
        CancellationToken cancellationToken = default);
}