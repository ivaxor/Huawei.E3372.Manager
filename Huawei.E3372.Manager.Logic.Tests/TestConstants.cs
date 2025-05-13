using Huawei.E3372.Manager.Logic.Entities;

namespace Huawei.E3372.Manager.Logic.Tests;

public static class TestConstants
{
    public static readonly Uri ModemUri = new Uri("http://192.168.41.1");

    public static readonly ApplicationSettings ApplicationSettings = new ApplicationSettings()
    {
        ModemTokenLifetime = TimeSpan.MaxValue,
        SmsPollBackgroundServiceInterval = TimeSpan.FromMinutes(1),
        SmsPollBackgroundServiceSetAsRead = false,
        SmsPollBackgroundServiceDelete = false,
        StatusPollBackgroundServiceInterval = TimeSpan.FromMinutes(1),
    };
}