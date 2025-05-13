namespace Huawei.E3372.Manager.Logic.Entities;

public record ApplicationSettings
{
    public TimeSpan ModemTokenLifetime { get; set; }

    public TimeSpan SmsPollBackgroundServiceInterval { get; set; }
    public bool SmsPollBackgroundServiceSetAsRead { get; set; }
    public bool SmsPollBackgroundServiceDelete { get; set; }

    public TimeSpan StatusPollBackgroundServiceInterval { get; set; }
}