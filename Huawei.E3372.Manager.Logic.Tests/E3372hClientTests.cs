using Huawei.E3372.Manager.Domain.Modem;
using Huawei.E3372.Manager.Domain.Modem.Api.Device;
using Huawei.E3372.Manager.Domain.Modem.Api.Dialup;
using Huawei.E3372.Manager.Domain.Modem.Api.Global;
using Huawei.E3372.Manager.Domain.Modem.Api.Monitoring;
using Huawei.E3372.Manager.Domain.Modem.Api.Net;
using Huawei.E3372.Manager.Domain.Modem.Api.OnlineUpdate;
using Huawei.E3372.Manager.Domain.Modem.Api.Pb;
using Huawei.E3372.Manager.Domain.Modem.Api.Pin;
using Huawei.E3372.Manager.Domain.Modem.Api.SdCard;
using Huawei.E3372.Manager.Domain.Modem.Api.Sms;
using Huawei.E3372.Manager.Domain.Modem.Api.User;
using Huawei.E3372.Manager.Domain.Modem.Api.WebServer;
using Huawei.E3372.Manager.Domain.Modem.Config.DeviceInformation;
using Huawei.E3372.Manager.Domain.Modem.Config.Global;
using Huawei.E3372.Manager.Domain.Modem.Config.PcAssistant;
using Huawei.E3372.Manager.Domain.Modem.Config.Ussd;
using Huawei.E3372.Manager.Logic.ModemClients;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Huawei.E3372.Manager.Logic.Tests;

[TestClass]
public sealed class E3372hClientTests
{
    private static readonly IMemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions());
    private static readonly ILogger<E3372hClient> logger = NullLogger<E3372hClient>.Instance;
    private static readonly E3372hClient client = new E3372hClient(memoryCache, logger);

    [DataRow(typeof(BasicInformation))]
    [DataRow(typeof(DeviceFeatureSwitch))]
    [DataRow(typeof(Information))]
    [DataRow(typeof(Signal))]

    [DataRow(typeof(MobileDataSwitch))]

    [DataRow(typeof(ModuleSwitch))]

    [DataRow(typeof(CheckNotification))]
    [DataRow(typeof(ConvergedStatus))]
    [DataRow(typeof(Status))]
    [DataRow(typeof(TrafficStatistics))]

    [DataRow(typeof(SignalPara))]

    [DataRow(typeof(AutoUpdateConfig))]
    [DataRow(typeof(OnlineUpdateConfiguration))]

    [DataRow(typeof(PbCount))]

    [DataRow(typeof(PinStatus))]
    [DataRow(typeof(SimLock))]

    [DataRow(typeof(SdCard))]

    [DataRow(typeof(SmsCount))]
    [DataRow(typeof(SmsFeatureSwitch))]
    [DataRow(typeof(SplitInfoSms))]

    [DataRow(typeof(HiLinkLogin))]
    [DataRow(typeof(StateLogin))]

    [DataRow(typeof(PublicKey))]
    [DataRow(typeof(SessionTokenInfo))]
    [DataRow(typeof(WhiteListSwitch))]

    [DataRow(typeof(AddParam))]

    [DataRow(typeof(Config))]
    [DataRow(typeof(LanguageList))]
    [DataRow(typeof(NetType))]

    [DataRow(typeof(PcAssistantConfig))]

    [DataRow(typeof(PrePaidUssd))]

    [DataRow(typeof(Domain.Modem.Config.Version))]

    [DataRow(typeof(DeviceName))]
    [DataRow(typeof(Operator))]
    [DataRow(typeof(UserConfig))]
    [DataTestMethod]
    public async Task GetAsync(Type type)
    {
        var methodInfo = typeof(E3372hClient).GetMethod("GetAsync").MakeGenericMethod(type);

        var baseUri = new Uri("http://192.168.41.1");
        var response = await (Task<IModemGetResponse>)methodInfo.Invoke(client, [baseUri, default(CancellationToken)])!;

        Assert.IsTrue(response.GetType() == type);
    }
}