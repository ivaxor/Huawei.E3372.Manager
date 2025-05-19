using Huawei.E3372.Manager.Logic;
using Huawei.E3372.Manager.Logic.Entities;
using Huawei.E3372.Manager.Logic.Modems;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Huawei.E3372.Manager.Runtime.Workers;

public sealed class SmsPollBackgroundService(
    IServiceScopeFactory serviceScopeFactory,
    IOptions<ApplicationSettings> applicationSettings,
    ILogger<SmsPollBackgroundService> logger)
    : BackgroundService
{
    public static readonly EventCallback OnChanged;

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation($"{nameof(SmsPollBackgroundService)} running.");

        using var timer = new PeriodicTimer(applicationSettings.Value.SmsPollBackgroundServiceInterval);
        try
        {
            while (await timer.WaitForNextTickAsync(cancellationToken))
            {
                await DoWorkAsync(cancellationToken);
            }
        }
        catch (OperationCanceledException)
        {
            logger.LogInformation($"{nameof(SmsPollBackgroundService)} is stopping.");
        }
    }

    internal async Task DoWorkAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation($"{nameof(SmsPollBackgroundService)} is working.");

        using var scope = serviceScopeFactory.CreateScope();
        await using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var smsService = scope.ServiceProvider.GetRequiredService<ISmsService>();

        var modems = await dbContext.Modems
            .AsNoTracking()
            .Include(m => m.Status)
            .Include(m => m.Settings)
            .Where(m => m.Settings.PollSms && (m.Settings.PollIncomingSms || m.Settings.PollOutgoingSms || m.Settings.PollDraftSms))
            .ToArrayAsync(cancellationToken);

        foreach (var modem in modems)
        {
            if (modem.Settings.PollIncomingSms)
                await PollIncomingSmsAsync(smsService, modem, cancellationToken);

            if (modem.Settings.PollOutgoingSms)
                await PollOutgoingSmsAsync(smsService, modem, cancellationToken);

            if (modem.Settings.PollDraftSms)
                await PollDraftSmsAsync(smsService, modem, cancellationToken);

        }

        await OnChanged.InvokeAsync();
    }

    internal async Task PollIncomingSmsAsync(
        ISmsService smsService,
        Modem modem,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var incomingResult = await smsService.PollIncomingAsync(modem, cancellationToken);
            if (!incomingResult.IsSuccess)
                logger.LogError("Failed to poll incoming SMS for {ModemUri}. Message: {ErrorMessage}.", modem.Uri, incomingResult.ErrorMessage);
        }
        catch (TaskCanceledException ex)
        {
            if (ex.Message.Contains("The request was canceled due to the configured HttpClient.Timeout"))
                logger.LogWarning($"{nameof(SmsPollBackgroundService)} failed to poll incoming SMS for {{ModemUri}} because of HTTP timeout.", modem.Uri);

            throw;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"{nameof(SmsPollBackgroundService)} failed to poll incoming SMS for {{ModemUri}}.", modem.Uri);
        }
    }

    internal async Task PollOutgoingSmsAsync(
        ISmsService smsService,
        Modem modem,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var outgoingResult = await smsService.PollOutgoingAsync(modem, cancellationToken);
            if (!outgoingResult.IsSuccess)
                logger.LogError("Failed to poll outgoing SMS for {ModemUri}. Message: {ErrorMessage}.", modem.Uri, outgoingResult.ErrorMessage);
        }
        catch (TaskCanceledException ex)
        {
            if (ex.Message.Contains("The request was canceled due to the configured HttpClient.Timeout"))
                logger.LogWarning($"{nameof(SmsPollBackgroundService)} failed to poll outgoing SMS for {{ModemUri}} because of HTTP timeout.", modem.Uri);

            throw;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"{nameof(SmsPollBackgroundService)} failed to poll outgoing SMS for {{ModemUri}}.", modem.Uri);
        }
    }

    internal async Task PollDraftSmsAsync(
        ISmsService smsService,
        Modem modem,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var draftResult = await smsService.PollDraftAsync(modem, cancellationToken);
            if (!draftResult.IsSuccess)
                logger.LogError("Failed to poll draft SMS for {ModemUri}. Message: {ErrorMessage}.", modem.Uri, draftResult.ErrorMessage);
        }
        catch (TaskCanceledException ex)
        {
            if (ex.Message.Contains("The request was canceled due to the configured HttpClient.Timeout"))
                logger.LogWarning($"{nameof(SmsPollBackgroundService)} failed to poll draft SMS for {{ModemUri}} because of HTTP timeout.", modem.Uri);

            throw;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"{nameof(SmsPollBackgroundService)} failed to poll draft SMS for {{ModemUri}}.", modem.Uri);
        }
    }
}