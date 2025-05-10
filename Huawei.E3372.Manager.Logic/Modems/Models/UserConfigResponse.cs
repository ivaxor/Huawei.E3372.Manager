using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models;

[XmlRoot("config")]
public record UserConfigResponse : IModemGetResponse
{

    [XmlElement("datalock")]
    public string DataLock { get; init; }

    [XmlElement("autounlock")]
    public bool AutoUnlock { get; init; }

    [XmlElement("pinautovalidate")]
    public string PinAutoValidate { get; init; }

    [XmlElement("imei_generator_model")]
    public string ImeiGeneratorModel { get; init; }

    [XmlElement("backup_imei")]
    public string BackupImei { get; init; }

    [XmlElement("autorun_imei_generator")]
    public bool AutoRunImeiGenerator { get; init; }

    [XmlElement("autoimei")]
    public bool AutoImei { get; init; }

    [XmlElement("hspa_locker")]
    public bool HspaLocker { get; init; }

    [XmlElement("add_param")]
    public bool AddParam { get; init; }

    [XmlElement("operator")]
    public bool Operator { get; init; }

    [XmlElement("websd")]
    public bool Websd { get; init; }

    [XmlElement("watchcat")]
    public bool Watchcat { get; init; }

    [XmlElement("watchcat_mode")]
    public string WatchcatMode { get; init; }

    [XmlElement("watchcat_period")]
    public string WatchcatPeriod { get; init; }

    [XmlElement("watchcat_forcedelay")]
    public int WatchcatForceDelay { get; init; }

    [XmlElement("watchcat_pinghosts")]
    public string WatchcatPingHosts { get; init; }

    [XmlElement("watchcat_pingperiod")]
    public string WatchcatPingPeriod { get; init; }

    [XmlElement("webui_mode")]
    public string WebuiMode { get; init; }

    [XmlElement("automaterial")]
    public bool AutoMaterial { get; init; }

    [XmlElement("search")]
    public string Search { get; init; }

    [XmlElement("main_bg")]
    public bool MainBg { get; init; }

    [XmlElement("force_new")]
    public string ForceNew { get; init; }

    [XmlElement("force_old")]
    public string ForceOld { get; init; }

    [XmlElement("force_both")]
    public string ForceBoth { get; init; }

    [XmlElement("force_new_home")]
    public bool ForceNewHome { get; init; }

    [XmlElement("force_old_home")]
    public bool ForceOldHome { get; init; }

    [XmlElement("force_new_statistic")]
    public bool ForceNewStatistic { get; init; }

    [XmlElement("force_old_statistic")]
    public bool ForceOldStatistic { get; init; }

    [XmlElement("force_both_statistic")]
    public bool ForceBothStatistic { get; init; }

    [XmlElement("force_new_sms")]
    public bool ForceNewSms { get; init; }

    [XmlElement("force_old_sms")]
    public bool ForceOldSms { get; init; }

    [XmlElement("force_new_ussd")]
    public bool ForceNewUssd { get; init; }

    [XmlElement("force_old_ussd")]
    public bool ForceOldUssd { get; init; }
}