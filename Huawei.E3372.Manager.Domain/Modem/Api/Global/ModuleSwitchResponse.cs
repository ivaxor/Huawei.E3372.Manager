using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Global;

[XmlRoot("response")]
public record ModuleSwitchResponse : IModemGetResponse
{
    [XmlElement("ussd_enabled")]
    public required int UssdEnabled { get; init; }

    [XmlElement("bbou_enabled")]
    public required int BbouEnabled { get; init; }

    [XmlElement("sms_enabled")]
    public required int SmsEnabled { get; init; }

    [XmlElement("sdcard_enabled")]
    public required int SdCardEnabled { get; init; }

    [XmlElement("wifi_enabled")]
    public required int WiFiEnabled { get; init; }

    [XmlElement("statistic_enabled")]
    public required int StatisticEnabled { get; init; }

    [XmlElement("help_enabled")]
    public required int HelpEnabled { get; init; }

    [XmlElement("stk_enabled")]
    public required int StkEnabled { get; init; }

    [XmlElement("pb_enabled")]
    public required int PbEnabled { get; init; }

    [XmlElement("dlna_enabled")]
    public required string DlnaEnabled { get; init; }

    [XmlElement("ota_enabled")]
    public required int OtaEnabled { get; init; }

    [XmlElement("wifioffload_enabled")]
    public required int WiFiOffloadEnabled { get; init; }

    [XmlElement("cradle_enabled")]
    public required int CradleEnabled { get; init; }

    [XmlElement("multssid_enable")]
    public required int MultiSsidEnable { get; init; }

    [XmlElement("ipv6_enabled")]
    public required int Ipv6Enabled { get; init; }

    [XmlElement("monthly_volume_enabled")]
    public required int MonthlyVolumeEnabled { get; init; }

    [XmlElement("powersave_enabled")]
    public required int PowerSaveEnabled { get; init; }

    [XmlElement("sntp_enabled")]
    public required int SntpEnabled { get; init; }

    [XmlElement("encrypt_enabled")]
    public required int EncryptEnabled { get; init; }

    [XmlElement("dataswitch_enabled")]
    public required int DataSwitchEnabled { get; init; }

    [XmlElement("poweroff_enabled")]
    public required int PowerOffEnabled { get; init; }

    [XmlElement("ecomode_enabled")]
    public required int EcoModeEnabled { get; init; }

    [XmlElement("zonetime_enabled")]
    public required int ZoneTimeEnabled { get; init; }

    [XmlElement("localupdate_enabled")]
    public required int LocalUpdateEnabled { get; init; }

    [XmlElement("cbs_enabled")]
    public required int CbsEnabled { get; init; }

    [XmlElement("qrcode_enabled")]
    public required int QrCodeEnabled { get; init; }

    [XmlElement("charger_enbaled")]
    public required int ChargerEnabled { get; init; }

    [XmlElement("apn_retry_enabled")]
    public required int ApnRetryEnabled { get; init; }

    [XmlElement("gdpr_enabled")]
    public required int GdprEnabled { get; init; }
}