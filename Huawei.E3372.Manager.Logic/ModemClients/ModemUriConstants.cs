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
using System.Collections.Frozen;

namespace Huawei.E3372.Manager.Logic.ModemClients;

internal static class ModemUriConstants
{
    public readonly static IReadOnlyDictionary<Type, string> TypeToRelativeUri = new Dictionary<Type, string>()
    {
        { typeof(BasicInformation), "/api/device/basic_information" },
        { typeof(DeviceFeatureSwitch), "/api/device/device-feature-switch" },
        { typeof(Information), "/api/device/information" },
        { typeof(Signal), "/api/device/signal" },

        { typeof(MobileDataSwitch), "/api/dialup/mobile-dataswitch" },

        { typeof(ModuleSwitch), "/api/global/module-switch" },

        { typeof(CheckNotification), "/api/monitoring/check-notifications" },
        { typeof(ConvergedStatus), "/api/monitoring/converged-status" },
        { typeof(Status), "/api/monitoring/status" },
        { typeof(TrafficStatistics), "/api/monitoring/traffic-statistics" },

        { typeof(SignalPara), "/api/net/signal-para" },

        { typeof(AutoUpdateConfig), "/api/online-update/autoupdate-config" },
        { typeof(OnlineUpdateConfiguration), "/api/online-update/configuration" },

        { typeof(PbCount), "/api/pb/pb-count" },
        { typeof(PbMatch), "/api/pb/pb-match" },

        { typeof(PinStatus), "/api/pin/status" },
        { typeof(SimLock), "/api/pin/simlock" },

        { typeof(SdCard), "/api/sdcard/sdcard" },

        { typeof(SmsCount), "/api/sms/sms-count" },
        { typeof(SmsFeatureSwitch), "/api/sms/sms-feature-switch" },
        { typeof(SmsList), "/api/sms/sms-list" },
        { typeof(SplitInfoSms), "/api/sms/splitinfo-sms" },

        { typeof(HiLinkLogin), "/api/user/hilink_login" },
        { typeof(StateLogin), "/api/user/state-login" },

        { typeof(PublicKey), "/api/webserver/publickey" },
        { typeof(SessionTokenInfo), "/api/webserver/SesTokInfo" },
        { typeof(WhiteListSwitch), "/api/webserver/white_list_switch" },

        { typeof(AddParam), "/config/deviceinformation/add_param.xml" },

        { typeof(Config), "/config/global/config.xml" },
        { typeof(LanguageList), "/config/global/languagelist.xml" },
        { typeof(NetType), "/config/global/net-type.xml" },

        { typeof(PcAssistantConfig), "/config/pcassistant/config.xml" },

        { typeof(PrePaidUssd), "/config/ussd/prepaidussd.xml" },

        { typeof(Domain.Modem.Config.Version), "/config/version.xml" },

        { typeof(DeviceName), "/devicename.cgi" },
        { typeof(FactoryReset), "/factoryreset.cgi" },
        { typeof(Operator), "/operator.cgi" },
        { typeof(UserConfig), "/user_config.data" },
    }.ToFrozenDictionary();
}