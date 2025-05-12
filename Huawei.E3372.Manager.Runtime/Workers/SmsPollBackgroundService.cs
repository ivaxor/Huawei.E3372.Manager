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
        logger.LogInformation($"{nameof(SmsPollBackgroundService)} is working");
        
        using var dbContext = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var incommingSmsService = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<ISmsService>();
        var outgoingSmsService = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<ISmsService>();
        var draftSmsService = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<ISmsService>();

        var modems = await dbContext.Modems
            .Include(m => m.Status)
            .AsNoTracking()
            .ToArrayAsync(cancellationToken);

        try
        {
            foreach (var modem in modems)
            {
                var (incomingResult, outgoingResult, draftResult) = await ConcurrentTasks.AsParallel(
                    incommingSmsService.PollIncomingAsync(modem, false, false, cancellationToken),
                    outgoingSmsService.PollOutgoingAsync(modem, false, cancellationToken),
                    draftSmsService.PollDraftAsync(modem, false, cancellationToken));

                if (!incomingResult.IsSuccess)
                    logger.LogError("Failed to poll incoming SMS for {ModemUri}. Message: {ErrorMessage}", modem.Uri, incomingResult.ErrorMessage);

                if (!outgoingResult.IsSuccess)
                    logger.LogError("Failed to poll outgoing SMS for {ModemUri}. Message: {ErrorMessage}", modem.Uri, outgoingResult.ErrorMessage);

                if (!draftResult.IsSuccess)
                    logger.LogError("Failed to poll draft SMS for {ModemUri}. Message: {ErrorMessage}", modem.Uri, outgoingResult.ErrorMessage);
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"{nameof(SmsPollBackgroundService)} failed");
        }
    }
}