using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Global;

[XmlRoot("response")]
public record ModuleSwitchResponse : IModemGetResponse
{
    [XmlElement("ussd_enabled")]
    public bool UssdEnabled { get; init; }

    [XmlElement("bbou_enabled")]
    public bool BbouEnabled { get; init; }

    [XmlElement("sms_enabled")]
    public bool SmsEnabled { get; init; }

    [XmlElement("sdcard_enabled")]
    public bool SdCardEnabled { get; init; }

    [XmlElement("wifi_enabled")]
    public bool WiFiEnabled { get; init; }

    [XmlElement("statistic_enabled")]
    public bool StatisticEnabled { get; init; }

    [XmlElement("help_enabled")]
    public bool HelpEnabled { get; init; }

    [XmlElement("stk_enabled")]
    public bool StkEnabled { get; init; }

    [XmlElement("pb_enabled")]
    public bool PbEnabled { get; init; }

    [XmlElement("dlna_enabled")]
    public string DlnaEnabled { get; init; }

    [XmlElement("ota_enabled")]
    public bool OtaEnabled { get; init; }

    [XmlElement("wifioffload_enabled")]
    public bool WiFiOffloadEnabled { get; init; }

    [XmlElement("cradle_enabled")]
    public bool CradleEnabled { get; init; }

    [XmlElement("multssid_enable")]
    public bool MultiSsidEnable { get; init; }

    [XmlElement("ipv6_enabled")]
    public bool Ipv6Enabled { get; init; }

    [XmlElement("monthly_volume_enabled")]
    public bool MonthlyVolumeEnabled { get; init; }

    [XmlElement("powersave_enabled")]
    public bool PowerSaveEnabled { get; init; }

    [XmlElement("sntp_enabled")]
    public bool SntpEnabled { get; init; }

    [XmlElement("encrypt_enabled")]
    public bool EncryptEnabled { get; init; }

    [XmlElement("dataswitch_enabled")]
    public bool DataSwitchEnabled { get; init; }

    [XmlElement("poweroff_enabled")]
    public bool PowerOffEnabled { get; init; }

    [XmlElement("ecomode_enabled")]
    public bool EcoModeEnabled { get; init; }

    [XmlElement("zonetime_enabled")]
    public bool ZoneTimeEnabled { get; init; }

    [XmlElement("localupdate_enabled")]
    public bool LocalUpdateEnabled { get; init; }

    [XmlElement("cbs_enabled")]
    public bool CbsEnabled { get; init; }

    [XmlElement("qrcode_enabled")]
    public bool QrCodeEnabled { get; init; }

    [XmlElement("charger_enbaled")]
    public bool ChargerEnabled { get; init; }

    [XmlElement("apn_retry_enabled")]
    public bool ApnRetryEnabled { get; init; }

    [XmlElement("gdpr_enabled")]
    public bool GdprEnabled { get; init; }
}