using Huawei.E3372.Manager.Logic.Entities;
using Huawei.E3372.Manager.Logic.Modems;
using Huawei.E3372.Manager.Logic.Modems.Models;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.Device;
using Microsoft.EntityFrameworkCore;

namespace Huawei.E3372.Manager.Logic;

public class ModemDiscoveryService(
    IModemClient modemClient,
    ApplicationDbContext dbContext)
    : IModemDiscoveryService
{
    public async Task<ServiceDataResult<Modem>> DiscoverAsync(
        Uri host,
        CancellationToken cancellationToken = default)
    {
        var modem = await dbContext.Modems.AsNoTracking().SingleOrDefaultAsync(m => m.Host == host, cancellationToken);
        if (modem != null)
            return ServiceDataResult<Modem>.Failure(ServiceResultErrorCode.Duplicate, modem);

        try
        {
            var deviceNameResponse = await modemClient.GetAsync<DeviceNameResponse>(host, cancellationToken);
            var informationResponse = await modemClient.GetAsync<InformationResponse>(host, cancellationToken);
            modem = new Modem(host, deviceNameResponse, informationResponse);
            await dbContext.AddAsync(modem, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return ServiceDataResult<Modem>.Success(modem);
        }
        catch (HttpRequestException)
        {
            return ServiceDataResult<Modem>.Failure(ServiceResultErrorCode.RemoteNotFound);
        }
    }

    public async Task<ServiceDataResult<Modem>> RediscoverAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var modem = await dbContext.Modems.AsNoTracking().SingleOrDefaultAsync(m => m.Id == id, cancellationToken);
        if (modem == null)
            return ServiceDataResult<Modem>.Failure(ServiceResultErrorCode.LocalNotFound);

        try
        {
            var deviceNameResponse = await modemClient.GetAsync<DeviceNameResponse>(modem.Host, cancellationToken);
            var informationResponse = await modemClient.GetAsync<InformationResponse>(modem.Host, cancellationToken);
            var updatedModem = new Modem(modem.Host, deviceNameResponse, informationResponse) with
            {
                Id = modem.Id,
            };

            if (modem != updatedModem)
            {
                dbContext.Update(modem);
                await dbContext.SaveChangesAsync(cancellationToken);
            }

            return ServiceDataResult<Modem>.Success(modem);
        }
        catch (HttpRequestException)
        {
            return ServiceDataResult<Modem>.Failure(ServiceResultErrorCode.RemoteNotFound);
        }
    }
}

public interface IModemDiscoveryService
{
    public Task<ServiceDataResult<Modem>> DiscoverAsync(
        Uri host,
        CancellationToken cancellationToken = default);

    public Task<ServiceDataResult<Modem>> RediscoverAsync(
        Guid id,
        CancellationToken cancellationToken = default);
}