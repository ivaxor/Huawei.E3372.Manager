using Huawei.E3372.Manager.Logic;
using Huawei.E3372.Manager.Logic.Modems;
using Microsoft.EntityFrameworkCore;

namespace Huawei.E3372.Manager.Worker;

public sealed class SmsPollBackgroundService(
    IServiceScopeFactory serviceScopeFactory,
    ILogger<SmsPollBackgroundService> logger)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation($"{nameof(SmsPollBackgroundService)} running");

        using var timer = new PeriodicTimer(TimeSpan.FromMinutes(1));
        try
        {
            while (await timer.WaitForNextTickAsync(cancellationToken))
            {
                await DoWorkAsync(cancellationToken);
            }
        }
        catch (OperationCanceledException)
        {
            logger.LogInformation($"{nameof(SmsPollBackgroundService)} is stopping");
        }
    }

    internal async Task DoWorkAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceScopeFactory.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var incommingSmsService = scope.ServiceProvider.GetRequiredService<ISmsService>();
        var outgoingSmsService = scope.ServiceProvider.GetRequiredService<ISmsService>();

        var modems = await dbContext.Modems.AsNoTracking().ToArrayAsync(cancellationToken);
        foreach (var modem in modems)
        {
            var (incomingResult, outgoingResult) = await ConcurrentTasks.AsParallel(
                incommingSmsService.PollIncomingAsync(modem, false, false, cancellationToken),
                outgoingSmsService.PollOutgoingAsync(modem, false, cancellationToken));

            if (!incomingResult.IsSuccess)
                logger.LogError("Failed to poll incoming SMS for {Uri}. Message: {ErrorMessage}", modem.Uri, incomingResult.ErrorMessage);

            if (!outgoingResult.IsSuccess)
                logger.LogError("Failed to poll outgoing SMS for {Uri}. Message: {ErrorMessage}", modem.Uri, outgoingResult.ErrorMessage);
        }
    }
}