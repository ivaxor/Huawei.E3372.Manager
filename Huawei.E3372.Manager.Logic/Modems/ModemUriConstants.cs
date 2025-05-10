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
using System.Collections.Frozen;

namespace Huawei.E3372.Manager.Logic.Modems;

internal static class ModemUriConstants
{
    public readonly static IReadOnlyDictionary<Type, string> TypeToRelativeUri = new Dictionary<Type, string>()
    {
        { typeof(BasicInformationResponse), "/api/device/basic_information" },
        { typeof(DeviceFeatureSwitchResponse), "/api/device/device-feature-switch" },
        { typeof(InformationResponse), "/api/device/information" },
        { typeof(SignalResponse), "/api/device/signal" },

        { typeof(DhcpSettingsResponse), "/api/dhcp/settings" },

        { typeof(MobileDataSwitchResponse), "/api/dialup/mobile-dataswitch" },

        { typeof(ModuleSwitchResponse), "/api/global/module-switch" },

        { typeof(CheckNotificationResponse), "/api/monitoring/check-notifications" },
        { typeof(ConvergedStatusResponse), "/api/monitoring/converged-status" },
        { typeof(MonthStatisticsResponse), "/api/monitoring/month_statistics" },
        { typeof(StartDateResponse), "/api/monitoring/start_date" },
        { typeof(StatusResponse), "/api/monitoring/status" },
        { typeof(TrafficStatisticsResponse), "/api/monitoring/traffic-statistics" },

        { typeof(NetFeatureSwitchReponse), "/api/net/net-feature-switch" },
        { typeof(NetModeListResponse), "/api/net/net-mode-list" },
        { typeof(Models.Api.Net.NetModeResponse), "/api/net/net-mode" },
        { typeof(RegisterResponse), "/api/net/register" },
        { typeof(SignalParaResponse), "/api/net/signal-para" },

        { typeof(AutoUpdateConfigResponse), "/api/online-update/autoupdate-config" },
        { typeof(OnlineUpdateConfigurationResponse), "/api/online-update/configuration" },

        { typeof(PbCountResponse), "/api/pb/pb-count" },
        { typeof(PbMatchResponse), "/api/pb/pb-match" },

        { typeof(PinStatusResponse), "/api/pin/status" },
        { typeof(SavePinResponse), "/api/pin/save-pin" },
        { typeof(SimLockResponse), "/api/pin/simlock" },

        { typeof(SdCardResponse), "/api/sdcard/sdcard" },

        { typeof(DmzResponse), "/api/security/dmz" },
        { typeof(FirewallSwitchResponse), "/api/security/firewall-switch" },
        { typeof(LanIpFilterResponse), "/api/security/lan-ip-filter" },
        { typeof(NatResponse), "/api/security/nat" },
        { typeof(SipResponse), "/api/security/sip" },
        { typeof(SpecialApplicationsResponse), "/api/security/special-applications" },
        { typeof(UpnpResponse), "/api/security/upnp" },
        { typeof(VirtualServersResponse), "/api/security/virtual-servers" },

        { typeof(DeleteSmsResponse), "/api/sms/delete-sms" },
        { typeof(SetReadResponse), "/api/sms/set-read" },
        { typeof(SmsCountResponse), "/api/sms/sms-count" },
        { typeof(SmsFeatureSwitchResponse), "/api/sms/sms-feature-switch" },
        { typeof(SmsListResponse), "/api/sms/sms-list" },
        { typeof(SplitInfoSmsResponse), "/api/sms/splitinfo-sms" },

        { typeof(StkGetMainResponse), "/api/stk/stk-get-main" },
        { typeof(StkQueryResponse), "/api/stk/stk-query" },

        { typeof(HiLinkLoginResponse), "/api/user/hilink_login" },
        { typeof(StateLoginResponse), "/api/user/state-login" },

        { typeof(PublicKeyResponse), "/api/webserver/publickey" },
        { typeof(SessionTokenInfoResponse), "/api/webserver/SesTokInfo" },
        { typeof(WhiteListSwitchResponse), "/api/webserver/white_list_switch" },

        { typeof(AddParamResponse), "/config/deviceinformation/add_param.xml" },

        { typeof(ConfigResponse), "/config/global/config.xml" },
        { typeof(LanguageListResponse), "/config/global/languagelist.xml" },
        { typeof(NetTypeResponse), "/config/global/net-type.xml" },

        { typeof(Models.Config.Network.NetModeResponse), "/config/network/net-mode.xml" },
        { typeof(NetworkModeResponse), "/config/network/networkmode.xml" },
        { typeof(OperatorListResponse), "/config/network/operatorlist.xml" },

        { typeof(PcAssistantConfigResponse), "/config/pcassistant/config.xml" },

        { typeof(PrePaidUssdResponse), "/config/ussd/prepaidussd.xml" },

        { typeof(VersionResponse), "/config/version.xml" },

        { typeof(DeviceNameResponse), "/devicename.cgi" },
        { typeof(FactoryResetResponse), "/factoryreset.cgi" },
        { typeof(OperatorResponse), "/operator.cgi" },
        { typeof(UserConfigResponse), "/user_config.data" },
    }.ToFrozenDictionary();
}