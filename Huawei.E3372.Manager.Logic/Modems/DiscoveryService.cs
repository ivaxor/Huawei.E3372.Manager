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
        string phoneNumber,
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
        await dbContext.AddAsync(modem, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        await statusService.PollAsync(modem, cancellationToken);
        await statusService.SetPhoneNumberAsync(modem, phoneNumber, cancellationToken);

        return ServiceDataResult<Modem>.Success(modem);
    }
}

public interface IDiscoveryService
{
    public Task<ServiceDataResult<Modem>> DiscoverAsync(
        Uri uri,
        string phoneNumber,
        CancellationToken cancellationToken = default);
}