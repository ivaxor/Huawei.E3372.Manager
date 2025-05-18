using Huawei.E3372.Manager.Logic.Entities;
using Huawei.E3372.Manager.Logic.Modems.Models;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.Device;
using Microsoft.EntityFrameworkCore;

namespace Huawei.E3372.Manager.Logic.Modems;

public class DiscoveryService(
    IModemClient modemClient,
    IStatusService statusService,
    ApplicationDbContext dbContext)
    : IDiscoveryService
{
    public async Task<ServiceDataResult<Modem>> DiscoverAsync(
        Uri uri,
        CancellationToken cancellationToken = default)
    {
        var modem = await dbContext.Modems.AsNoTracking().SingleOrDefaultAsync(m => m.Uri == uri, cancellationToken);
        if (modem != null)
            return ServiceDataResult<Modem>.Failure(ServiceResultErrorCode.Duplicate, data: modem);

        DeviceNameResponse deviceNameResponse;
        InformationResponse informationResponse;
        try
        {
            (deviceNameResponse, informationResponse) = await ConcurrentTasks.AsParallel(
                modemClient.GetAsync<DeviceNameResponse>(uri, cancellationToken),
                modemClient.GetAsync<InformationResponse>(uri, cancellationToken));
        }
        catch (HttpRequestException ex)
        {
            return ServiceDataResult<Modem>.Failure(ServiceResultErrorCode.RemoteNotFound, ex.Message);
        }

        modem = new Modem(uri, deviceNameResponse, informationResponse)
        {
            Id = Guid.NewGuid(),
        };
        var modemSettings = new ModemSettings()
        {
            ModemId = modem.Id,
            ModemTokenLifeTime = TimeOnly.FromTimeSpan(TimeSpan.FromMinutes(3)),

            PollStatus = true,
            PollStatusInterval = TimeOnly.FromTimeSpan(TimeSpan.FromMinutes(5)),

            PollSms = true,
            PollSmsInterval = TimeOnly.FromTimeSpan(TimeSpan.FromMinutes(1)),
            PollIncomingSms = true,
            PollOutgoingSms = true,
            PollDraftSms = true,
        };

        await dbContext.AddAsync(modem, cancellationToken);
        await dbContext.AddAsync(modemSettings, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        await statusService.PollAsync(modem, cancellationToken);

        return ServiceDataResult<Modem>.Success(modem);
    }
}

public interface IDiscoveryService
{
    public Task<ServiceDataResult<Modem>> DiscoverAsync(
        Uri uri,
        CancellationToken cancellationToken = default);
}