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

        modem = new Modem()
        {
            Id = Guid.NewGuid(),
            Uri = uri,
            CreatedAt = DateTimeOffset.UtcNow,
            LastUpdatedAt = DateTimeOffset.UtcNow,
        };

        DeviceNameResponse deviceNameResponse;
        InformationResponse informationResponse;
        try
        {
            (deviceNameResponse, informationResponse) = await ConcurrentTasks.AsParallel(
                modemClient.GetAsync<DeviceNameResponse>(modem, cancellationToken),
                modemClient.GetAsync<InformationResponse>(modem, cancellationToken));
        }
        catch (HttpRequestException ex)
        {
            return ServiceDataResult<Modem>.Failure(ServiceResultErrorCode.RemoteNotFound, ex.Message);
        }

        modem = modem with
        {
            DeviceName = deviceNameResponse.Name,

            SerialNumber = informationResponse.SerialNumber,
            IMEI = informationResponse.Imei,
            MacAddress = informationResponse.MacAddress1 ?? informationResponse.MacAddress2,
        };

        var modemSettings = new ModemSettings()
        {
            ModemId = modem.Id,
            TokenLifeTime = TimeOnly.FromTimeSpan(TimeSpan.FromMinutes(3)),

            PollStatus = true,

            PollSms = true,
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