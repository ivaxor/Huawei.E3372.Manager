using Huawei.E3372.Manager.Logic.Modems;
using Huawei.E3372.Manager.Logic.Modems.Models;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.Device;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.Dhcp;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.Dialup;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.Global;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.Monitoring;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.Net;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.OnlineUpdate;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.Pb;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.Pin;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.SdCard;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.Security;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.Sms;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.Stk;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.User;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.WebServer;
using Huawei.E3372.Manager.Logic.Modems.Models.Config;
using Huawei.E3372.Manager.Logic.Modems.Models.Config.DeviceInformation;
using Huawei.E3372.Manager.Logic.Modems.Models.Config.Global;
using Huawei.E3372.Manager.Logic.Modems.Models.Config.Network;
using Huawei.E3372.Manager.Logic.Modems.Models.Config.PcAssistant;
using Huawei.E3372.Manager.Logic.Modems.Models.Config.Ussd;
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
    [DataRow(typeof(Modems.Models.Api.Net.NetModeResponse))]
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

    [DataRow(typeof(StkQueryResponse))]

    [DataRow(typeof(HiLinkLoginResponse))]
    [DataRow(typeof(StateLoginResponse))]

    [DataRow(typeof(PublicKeyResponse))]
    [DataRow(typeof(SessionTokenInfoResponse))]
    [DataRow(typeof(WhiteListSwitchResponse))]

    [DataRow(typeof(AddParamResponse))]

    [DataRow(typeof(ConfigResponse))]
    [DataRow(typeof(LanguageListResponse))]
    [DataRow(typeof(NetTypeResponse))]

    [DataRow(typeof(Modems.Models.Config.Network.NetModeResponse))]
    [DataRow(typeof(NetworkModeResponse))]
    [DataRow(typeof(OperatorListResponse))]

    [DataRow(typeof(PcAssistantConfigResponse))]

    [DataRow(typeof(PrePaidUssdResponse))]

    [DataRow(typeof(VersionResponse))]

    [DataRow(typeof(DeviceNameResponse))]
    [DataRow(typeof(OperatorResponse))]
    [DataRow(typeof(UserConfigResponse))]
    [DataTestMethod]
    public async Task GetAsync_All_ReturnsValidType(Type type)
    {
        var methodInfo = typeof(E3372hClient).GetMethod("GetAsync")!.MakeGenericMethod(type);
        var baseUri = new Uri("http://192.168.41.1");

        var task = methodInfo.Invoke(client, [baseUri, default(CancellationToken)])!;
        var response = await GetTaskResult(task);

        Assert.IsTrue(response.GetType() == type);
    }

    [TestMethod]
    public async Task PostAsync_SmsList_ReturnsValidType()
    {
        var methodInfo = typeof(E3372hClient).GetMethod("PostAsync")!.MakeGenericMethod(typeof(SmsListRequest), typeof(SmsListResponse));
        var baseUri = new Uri("http://192.168.41.1");                
        var model = new SmsListRequest()
        {
            PageIndex = 1,
            ReadCount = 50,
            BoxType = 1,
        };

        var task = methodInfo.Invoke(client, [baseUri, model, default(CancellationToken)])!;
        var response = await GetTaskResult(task);

        Assert.IsTrue(response is SmsListResponse);
    }

    internal static async Task<object> GetTaskResult(object taskObject)
    {
        var task = (Task)taskObject;
        await task;

        var resultProperty = task.GetType().GetProperty("Result");
        return resultProperty!.GetValue(taskObject)!;
    }
}