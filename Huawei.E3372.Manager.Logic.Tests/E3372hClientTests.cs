using Huawei.E3372.Manager.Domain.Modem;
using Huawei.E3372.Manager.Domain.Modem.Api.Device;
using Huawei.E3372.Manager.Domain.Modem.Api.Dhcp;
using Huawei.E3372.Manager.Domain.Modem.Api.Dialup;
using Huawei.E3372.Manager.Domain.Modem.Api.Global;
using Huawei.E3372.Manager.Domain.Modem.Api.Monitoring;
using Huawei.E3372.Manager.Domain.Modem.Api.Net;
using Huawei.E3372.Manager.Domain.Modem.Api.OnlineUpdate;
using Huawei.E3372.Manager.Domain.Modem.Api.Pb;
using Huawei.E3372.Manager.Domain.Modem.Api.Pin;
using Huawei.E3372.Manager.Domain.Modem.Api.SdCard;
using Huawei.E3372.Manager.Domain.Modem.Api.Security;
using Huawei.E3372.Manager.Domain.Modem.Api.Sms;
using Huawei.E3372.Manager.Domain.Modem.Api.User;
using Huawei.E3372.Manager.Domain.Modem.Api.WebServer;
using Huawei.E3372.Manager.Domain.Modem.Config;
using Huawei.E3372.Manager.Domain.Modem.Config.DeviceInformation;
using Huawei.E3372.Manager.Domain.Modem.Config.Global;
using Huawei.E3372.Manager.Domain.Modem.Config.Network;
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

    [DataRow(typeof(BasicInformationResponse))]
    [DataRow(typeof(DeviceFeatureSwitchResponse))]
    [DataRow(typeof(InformationResponse))]
    [DataRow(typeof(SignalResponse))]

    [DataRow(typeof(DhcpSettingsResponse))]

    [DataRow(typeof(MobileDataSwitchResponse))]

    [DataRow(typeof(ModuleSwitchResponse))]

    [DataRow(typeof(CheckNotificationResponse))]
    [DataRow(typeof(ConvergedStatusResponse))]
    [DataRow(typeof(MonthStatisticsResponse))]
    [DataRow(typeof(StartDateResponse))]
    [DataRow(typeof(StatusResponse))]
    [DataRow(typeof(TrafficStatisticsResponse))]

    [DataRow(typeof(NetFeatureSwitchReponse))]
    [DataRow(typeof(NetModeListResponse))]
    [DataRow(typeof(Domain.Modem.Api.Net.NetModeResponse))]
    [DataRow(typeof(RegisterResponse))]
    [DataRow(typeof(SignalParaResponse))]

    [DataRow(typeof(AutoUpdateConfigResponse))]
    [DataRow(typeof(OnlineUpdateConfigurationResponse))]

    [DataRow(typeof(PbCountResponse))]

    [DataRow(typeof(PinStatusResponse))]
    [DataRow(typeof(SavePinResponse))]
    [DataRow(typeof(SimLockResponse))]

    [DataRow(typeof(SdCardResponse))]

    [DataRow(typeof(DmzResponse))]
    [DataRow(typeof(FirewallSwitchResponse))]
    [DataRow(typeof(LanIpFilterResponse))]
    [DataRow(typeof(NatResponse))]
    [DataRow(typeof(SipResponse))]
    [DataRow(typeof(SpecialApplicationsResponse))]
    [DataRow(typeof(UpnpResponse))]
    [DataRow(typeof(VirtualServersResponse))]

    [DataRow(typeof(SmsCountResponse))]
    [DataRow(typeof(SmsFeatureSwitchResponse))]
    [DataRow(typeof(SplitInfoSmsResponse))]

    [DataRow(typeof(HiLinkLoginResponse))]
    [DataRow(typeof(StateLoginResponse))]

    [DataRow(typeof(PublicKeyResponse))]
    [DataRow(typeof(SessionTokenInfoResponse))]
    [DataRow(typeof(WhiteListSwitchResponse))]

    [DataRow(typeof(AddParamResponse))]

    [DataRow(typeof(ConfigResponse))]
    [DataRow(typeof(LanguageListResponse))]
    [DataRow(typeof(NetTypeResponse))]

    [DataRow(typeof(Domain.Modem.Config.Network.NetModeResponse))]
    [DataRow(typeof(NetworkModeResponse))]
    [DataRow(typeof(OperatorListResponse))]

    [DataRow(typeof(PcAssistantConfigResponse))]

    [DataRow(typeof(PrePaidUssdResponse))]

    [DataRow(typeof(VersionResponse))]

    [DataRow(typeof(DeviceNameResponse))]
    [DataRow(typeof(OperatorResponse))]
    [DataRow(typeof(UserConfigResponse))]
    [DataTestMethod]
    public async Task GetAsync(Type type)
    {
        var methodInfo = typeof(E3372hClient).GetMethod("GetAsync").MakeGenericMethod(type);

        var baseUri = new Uri("http://192.168.41.1");
        var response = await (Task<IModemGetResponse>)methodInfo.Invoke(client, [baseUri, default(CancellationToken)])!;

        Assert.IsTrue(response.GetType() == type);
    }
}