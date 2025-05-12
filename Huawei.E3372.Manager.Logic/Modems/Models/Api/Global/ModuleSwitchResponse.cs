using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Global;

[XmlRoot("response")]
public record ModuleSwitchResponse : IModemGetResponse
{
    [XmlElement("ussd_enabled")]
    public bool UssdEnabled { get; set; }

    [XmlElement("bbou_enabled")]
    public bool BbouEnabled { get; set; }

    [XmlElement("sms_enabled")]
    public bool SmsEnabled { get; set; }

    [XmlElement("sdcard_enabled")]
    public bool SdCardEnabled { get; set; }

    [XmlElement("wifi_enabled")]
    public bool WiFiEnabled { get; set; }

    [XmlElement("statistic_enabled")]
    public bool StatisticEnabled { get; set; }

    [XmlElement("help_enabled")]
    public bool HelpEnabled { get; set; }

    [XmlElement("stk_enabled")]
    public bool StkEnabled { get; set; }

    [XmlElement("pb_enabled")]
    public bool PbEnabled { get; set; }

    [XmlElement("dlna_enabled")]
    public string DlnaEnabled { get; set; }

    [XmlElement("ota_enabled")]
    public bool OtaEnabled { get; set; }

    [XmlElement("wifioffload_enabled")]
    public bool WiFiOffloadEnabled { get; set; }

    [XmlElement("cradle_enabled")]
    public bool CradleEnabled { get; set; }

    [XmlElement("multssid_enable")]
    public bool MultiSsidEnable { get; set; }

    [XmlElement("ipv6_enabled")]
    public bool Ipv6Enabled { get; set; }

    [XmlElement("monthly_volume_enabled")]
    public bool MonthlyVolumeEnabled { get; set; }

    [XmlElement("powersave_enabled")]
    public bool PowerSaveEnabled { get; set; }

    [XmlElement("sntp_enabled")]
    public bool SntpEnabled { get; set; }

    [XmlElement("encrypt_enabled")]
    public bool EncryptEnabled { get; set; }

    [XmlElement("dataswitch_enabled")]
    public bool DataSwitchEnabled { get; set; }

    [XmlElement("poweroff_enabled")]
    public bool PowerOffEnabled { get; set; }

    [XmlElement("ecomode_enabled")]
    public bool EcoModeEnabled { get; set; }

    [XmlElement("zonetime_enabled")]
    public bool ZoneTimeEnabled { get; set; }

    [XmlElement("localupdate_enabled")]
    public bool LocalUpdateEnabled { get; set; }

    [XmlElement("cbs_enabled")]
    public bool CbsEnabled { get; set; }

    [XmlElement("qrcode_enabled")]
    public bool QrCodeEnabled { get; set; }

    [XmlElement("charger_enbaled")]
    public bool ChargerEnabled { get; set; }

    [XmlElement("apn_retry_enabled")]
    public bool ApnRetryEnabled { get; set; }

    [XmlElement("gdpr_enabled")]
    public bool GdprEnabled { get; set; }
}