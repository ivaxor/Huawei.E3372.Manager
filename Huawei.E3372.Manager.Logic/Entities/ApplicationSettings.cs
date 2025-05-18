namespace Huawei.E3372.Manager.Logic.Entities;

public record ApplicationSettings
{
    public TimeSpan SmsPollBackgroundServiceInterval { get; set; }
    public TimeSpan StatusPollBackgroundServiceInterval { get; set; }
}