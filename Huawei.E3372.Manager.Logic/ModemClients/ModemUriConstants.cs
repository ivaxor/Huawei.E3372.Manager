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
using Huawei.E3372.Manager.Domain.Modem.Config;
using Huawei.E3372.Manager.Domain.Modem.Config.DeviceInformation;
using Huawei.E3372.Manager.Domain.Modem.Config.Global;
using Huawei.E3372.Manager.Domain.Modem.Config.PcAssistant;
using Huawei.E3372.Manager.Domain.Modem.Config.Ussd;
using System.Collections.Frozen;

namespace Huawei.E3372.Manager.Logic.ModemClients;

internal static class ModemUriConstants
{
    public readonly static IReadOnlyDictionary<Type, string> TypeToRelativeUri = new Dictionary<Type, string>()
    {
        { typeof(BasicInformationResponse), "/api/device/basic_information" },
        { typeof(DeviceFeatureSwitchResponse), "/api/device/device-feature-switch" },
        { typeof(InformationResponse), "/api/device/information" },
        { typeof(SignalResponse), "/api/device/signal" },

        { typeof(MobileDataSwitchResponse), "/api/dialup/mobile-dataswitch" },

        { typeof(ModuleSwitchResponse), "/api/global/module-switch" },

        { typeof(CheckNotificationResponse), "/api/monitoring/check-notifications" },
        { typeof(ConvergedStatusResponse), "/api/monitoring/converged-status" },
        { typeof(StatusResponse), "/api/monitoring/status" },
        { typeof(TrafficStatisticsResponse), "/api/monitoring/traffic-statistics" },

        { typeof(SignalParaResponse), "/api/net/signal-para" },

        { typeof(AutoUpdateConfigResponse), "/api/online-update/autoupdate-config" },
        { typeof(OnlineUpdateConfigurationResponse), "/api/online-update/configuration" },

        { typeof(PbCountResponse), "/api/pb/pb-count" },
        { typeof(PbMatchResponse), "/api/pb/pb-match" },

        { typeof(PinStatusResponse), "/api/pin/status" },
        { typeof(SimLockResponse), "/api/pin/simlock" },

        { typeof(SdCardResponse), "/api/sdcard/sdcard" },

        { typeof(SmsCountResponse), "/api/sms/sms-count" },
        { typeof(SmsFeatureSwitchResponse), "/api/sms/sms-feature-switch" },
        { typeof(SmsListResponse), "/api/sms/sms-list" },
        { typeof(SplitInfoSmsResponse), "/api/sms/splitinfo-sms" },

        { typeof(HiLinkLoginResponse), "/api/user/hilink_login" },
        { typeof(StateLoginResponse), "/api/user/state-login" },

        { typeof(PublicKeyResponse), "/api/webserver/publickey" },
        { typeof(SessionTokenInfoResponse), "/api/webserver/SesTokInfo" },
        { typeof(WhiteListSwitchResponse), "/api/webserver/white_list_switch" },

        { typeof(AddParamResponse), "/config/deviceinformation/add_param.xml" },

        { typeof(ConfigResponse), "/config/global/config.xml" },
        { typeof(LanguageListResponse), "/config/global/languagelist.xml" },
        { typeof(NetTypeResponse), "/config/global/net-type.xml" },

        { typeof(PcAssistantConfigResponse), "/config/pcassistant/config.xml" },

        { typeof(PrePaidUssdResponse), "/config/ussd/prepaidussd.xml" },

        { typeof(VersionResponse), "/config/version.xml" },

        { typeof(DeviceNameResponse), "/devicename.cgi" },
        { typeof(FactoryResetResponse), "/factoryreset.cgi" },
        { typeof(OperatorResponse), "/operator.cgi" },
        { typeof(UserConfigResponse), "/user_config.data" },
    }.ToFrozenDictionary();
}