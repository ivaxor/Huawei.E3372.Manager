using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Global;

[XmlRoot("response")]
public record ModuleSwitch : IModemGetResponse
{
    [XmlElement("ussd_enabled")]
    public int UssdEnabled { get; init; }

    [XmlElement("bbou_enabled")]
    public int BbouEnabled { get; init; }

    [XmlElement("sms_enabled")]
    public int SmsEnabled { get; init; }

    [XmlElement("sdcard_enabled")]
    public int SdCardEnabled { get; init; }

    [XmlElement("wifi_enabled")]
    public int WiFiEnabled { get; init; }

    [XmlElement("statistic_enabled")]
    public int StatisticEnabled { get; init; }

    [XmlElement("help_enabled")]
    public int HelpEnabled { get; init; }

    [XmlElement("stk_enabled")]
    public int StkEnabled { get; init; }

    [XmlElement("pb_enabled")]
    public int PbEnabled { get; init; }

    [XmlElement("dlna_enabled")]
    public string? DlnaEnabled { get; init; }

    [XmlElement("ota_enabled")]
    public int OtaEnabled { get; init; }

    [XmlElement("wifioffload_enabled")]
    public int WiFiOffloadEnabled { get; init; }

    [XmlElement("cradle_enabled")]
    public int CradleEnabled { get; init; }

    [XmlElement("multssid_enable")]
    public int MultiSsidEnable { get; init; }

    [XmlElement("ipv6_enabled")]
    public int Ipv6Enabled { get; init; }

    [XmlElement("monthly_volume_enabled")]
    public int MonthlyVolumeEnabled { get; init; }

    [XmlElement("powersave_enabled")]
    public int PowerSaveEnabled { get; init; }

    [XmlElement("sntp_enabled")]
    public int SntpEnabled { get; init; }

    [XmlElement("encrypt_enabled")]
    public int EncryptEnabled { get; init; }

    [XmlElement("dataswitch_enabled")]
    public int DataSwitchEnabled { get; init; }

    [XmlElement("poweroff_enabled")]
    public int PowerOffEnabled { get; init; }

    [XmlElement("ecomode_enabled")]
    public int EcoModeEnabled { get; init; }

    [XmlElement("zonetime_enabled")]
    public int ZoneTimeEnabled { get; init; }

    [XmlElement("localupdate_enabled")]
    public int LocalUpdateEnabled { get; init; }

    [XmlElement("cbs_enabled")]
    public int CbsEnabled { get; init; }

    [XmlElement("qrcode_enabled")]
    public int QrCodeEnabled { get; init; }

    [XmlElement("charger_enbaled")]
    public int ChargerEnabled { get; init; }

    [XmlElement("apn_retry_enabled")]
    public int ApnRetryEnabled { get; init; }

    [XmlElement("gdpr_enabled")]
    public int GdprEnabled { get; init; }
}