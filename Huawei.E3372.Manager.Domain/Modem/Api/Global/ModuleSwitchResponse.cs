using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Global;

[XmlRoot("response")]
public record ModuleSwitchResponse : IModemGetResponse
{
    [XmlElement("ussd_enabled")]
    public required bool UssdEnabled { get; init; }

    [XmlElement("bbou_enabled")]
    public required bool BbouEnabled { get; init; }

    [XmlElement("sms_enabled")]
    public required bool SmsEnabled { get; init; }

    [XmlElement("sdcard_enabled")]
    public required bool SdCardEnabled { get; init; }

    [XmlElement("wifi_enabled")]
    public required bool WiFiEnabled { get; init; }

    [XmlElement("statistic_enabled")]
    public required bool StatisticEnabled { get; init; }

    [XmlElement("help_enabled")]
    public required bool HelpEnabled { get; init; }

    [XmlElement("stk_enabled")]
    public required bool StkEnabled { get; init; }

    [XmlElement("pb_enabled")]
    public required bool PbEnabled { get; init; }

    [XmlElement("dlna_enabled")]
    public required string DlnaEnabled { get; init; }

    [XmlElement("ota_enabled")]
    public required bool OtaEnabled { get; init; }

    [XmlElement("wifioffload_enabled")]
    public required bool WiFiOffloadEnabled { get; init; }

    [XmlElement("cradle_enabled")]
    public required bool CradleEnabled { get; init; }

    [XmlElement("multssid_enable")]
    public required bool MultiSsidEnable { get; init; }

    [XmlElement("ipv6_enabled")]
    public required bool Ipv6Enabled { get; init; }

    [XmlElement("monthly_volume_enabled")]
    public required bool MonthlyVolumeEnabled { get; init; }

    [XmlElement("powersave_enabled")]
    public required bool PowerSaveEnabled { get; init; }

    [XmlElement("sntp_enabled")]
    public required bool SntpEnabled { get; init; }

    [XmlElement("encrypt_enabled")]
    public required bool EncryptEnabled { get; init; }

    [XmlElement("dataswitch_enabled")]
    public required bool DataSwitchEnabled { get; init; }

    [XmlElement("poweroff_enabled")]
    public required bool PowerOffEnabled { get; init; }

    [XmlElement("ecomode_enabled")]
    public required bool EcoModeEnabled { get; init; }

    [XmlElement("zonetime_enabled")]
    public required bool ZoneTimeEnabled { get; init; }

    [XmlElement("localupdate_enabled")]
    public required bool LocalUpdateEnabled { get; init; }

    [XmlElement("cbs_enabled")]
    public required bool CbsEnabled { get; init; }

    [XmlElement("qrcode_enabled")]
    public required bool QrCodeEnabled { get; init; }

    [XmlElement("charger_enbaled")]
    public required bool ChargerEnabled { get; init; }

    [XmlElement("apn_retry_enabled")]
    public required bool ApnRetryEnabled { get; init; }

    [XmlElement("gdpr_enabled")]
    public required bool GdprEnabled { get; init; }
}