using Huawei.E3372.Manager.Logic;
using Huawei.E3372.Manager.Logic.Entities;
using Huawei.E3372.Manager.Logic.Modems;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Huawei.E3372.Manager.Runtime.Workers;

public sealed class StatusPollBackgroundService(
    IServiceScopeFactory serviceScopeFactory,
    IOptions<ApplicationSettings> applicationSettings,
    ILogger<StatusPollBackgroundService> logger)
    : BackgroundService
{
    public static readonly EventCallback OnChanged;

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation($"{nameof(StatusPollBackgroundService)} running.");

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
            logger.LogInformation($"{nameof(StatusPollBackgroundService)} is stopping.");
        }
    }

    internal async Task DoWorkAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation($"{nameof(StatusPollBackgroundService)} is working.");

        using var scope = serviceScopeFactory.CreateScope();
        await using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var statusService = scope.ServiceProvider.GetRequiredService<IStatusService>();

        var modems = await dbContext.Modems
            .AsNoTracking()
            .Where(m => m.Settings.PollStatus)
            .ToArrayAsync(cancellationToken);

        foreach (var modem in modems)
        {
            try
            {
                var statusResult = await statusService.PollAsync(modem, cancellationToken);

                if (!statusResult.IsSuccess)
                    logger.LogError("Failed to poll status for {ModemUri}. Message: {ErrorMessage}.", modem.Uri, statusResult.ErrorMessage);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"{nameof(StatusPollBackgroundService)} failed for {{ModemUri}}.", modem.Uri);
            }
        }

        await OnChanged.InvokeAsync();
    }
}