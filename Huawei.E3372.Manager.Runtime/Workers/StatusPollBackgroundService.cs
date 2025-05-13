using Huawei.E3372.Manager.Logic;
using Huawei.E3372.Manager.Logic.Entities;
using Huawei.E3372.Manager.Logic.Modems;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Huawei.E3372.Manager.Runtime.Workers;

public sealed class StatusPollBackgroundService(
    IServiceScopeFactory serviceScopeFactory,
    IOptions<ApplicationSettings> applicationSettings,
    ILogger<StatusPollBackgroundService> logger)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation($"{nameof(StatusPollBackgroundService)} running");

        using var timer = new PeriodicTimer(applicationSettings.Value.StatusPollBackgroundServiceInterval);
        try
        {
            while (await timer.WaitForNextTickAsync(cancellationToken))
            {
                await DoWorkAsync(cancellationToken);
            }
        }
        catch (OperationCanceledException)
        {
            logger.LogInformation($"{nameof(StatusPollBackgroundService)} is stopping");
        }
    }

    internal async Task DoWorkAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation($"{nameof(StatusPollBackgroundService)} is working");

        using var dbContext = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var statusService = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<IStatusService>();

        var modems = await dbContext.Modems
            .AsNoTracking()
            .ToArrayAsync(cancellationToken);

        try
        {
            foreach (var modem in modems)
            {
                var statusResult = await statusService.PollAsync(modem);

                if (!statusResult.IsSuccess)
                    logger.LogError("Failed to poll status for {ModemUri}. Message: {ErrorMessage}", modem.Uri, statusResult.ErrorMessage);
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"{nameof(StatusPollBackgroundService)} failed");
        }
    }
}