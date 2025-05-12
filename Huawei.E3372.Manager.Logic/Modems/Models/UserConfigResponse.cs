using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models;

[XmlRoot("config")]
public record UserConfigResponse : IModemGetResponse
{

    [XmlElement("datalock")]
    public string DataLock { get; set; }

    [XmlElement("autounlock")]
    public bool AutoUnlock { get; set; }

    [XmlElement("pinautovalidate")]
    public string PinAutoValidate { get; set; }

    [XmlElement("imei_generator_model")]
    public string ImeiGeneratorModel { get; set; }

    [XmlElement("backup_imei")]
    public string BackupImei { get; set; }

    [XmlElement("autorun_imei_generator")]
    public bool AutoRunImeiGenerator { get; set; }

    [XmlElement("autoimei")]
    public bool AutoImei { get; set; }

    [XmlElement("hspa_locker")]
    public bool HspaLocker { get; set; }

    [XmlElement("add_param")]
    public bool AddParam { get; set; }

    [XmlElement("operator")]
    public bool Operator { get; set; }

    [XmlElement("websd")]
    public bool Websd { get; set; }

    [XmlElement("watchcat")]
    public bool Watchcat { get; set; }

    [XmlElement("watchcat_mode")]
    public string WatchcatMode { get; set; }

    [XmlElement("watchcat_period")]
    public string WatchcatPeriod { get; set; }

    [XmlElement("watchcat_forcedelay")]
    public int WatchcatForceDelay { get; set; }

    [XmlElement("watchcat_pinghosts")]
    public string WatchcatPingHosts { get; set; }

    [XmlElement("watchcat_pingperiod")]
    public string WatchcatPingPeriod { get; set; }

    [XmlElement("webui_mode")]
    public string WebuiMode { get; set; }

    [XmlElement("automaterial")]
    public bool AutoMaterial { get; set; }

    [XmlElement("search")]
    public string Search { get; set; }

    [XmlElement("main_bg")]
    public bool MainBg { get; set; }

    [XmlElement("force_new")]
    public string ForceNew { get; set; }

    [XmlElement("force_old")]
    public string ForceOld { get; set; }

    [XmlElement("force_both")]
    public string ForceBoth { get; set; }

    [XmlElement("force_new_home")]
    public bool ForceNewHome { get; set; }

    [XmlElement("force_old_home")]
    public bool ForceOldHome { get; set; }

    [XmlElement("force_new_statistic")]
    public bool ForceNewStatistic { get; set; }

    [XmlElement("force_old_statistic")]
    public bool ForceOldStatistic { get; set; }

    [XmlElement("force_both_statistic")]
    public bool ForceBothStatistic { get; set; }

    [XmlElement("force_new_sms")]
    public bool ForceNewSms { get; set; }

    [XmlElement("force_old_sms")]
    public bool ForceOldSms { get; set; }

    [XmlElement("force_new_ussd")]
    public bool ForceNewUssd { get; set; }

    [XmlElement("force_old_ussd")]
    public bool ForceOldUssd { get; set; }
}