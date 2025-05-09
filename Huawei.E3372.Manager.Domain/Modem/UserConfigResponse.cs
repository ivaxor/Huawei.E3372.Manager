using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem;

[XmlRoot("config")]
public record UserConfigResponse : IModemGetResponse
{

    [XmlElement("datalock")]
    public required string Datalock { get; init; }

    [XmlElement("autounlock")]
    public bool Autounlock { get; init; }

    [XmlElement("pinautovalidate")]
    public required string Pinautovalidate { get; init; }

    [XmlElement("imei_generator_model")]
    public required string ImeiGeneratorModel { get; init; }

    [XmlElement("backup_imei")]
    public required string BackupImei { get; init; }

    [XmlElement("autorun_imei_generator")]
    public bool AutorunImeiGenerator { get; init; }

    [XmlElement("autoimei")]
    public bool Autoimei { get; init; }

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
    public required string WatchcatMode { get; init; }

    [XmlElement("watchcat_period")]
    public required string WatchcatPeriod { get; init; }

    [XmlElement("watchcat_forcedelay")]
    public required int WatchcatForcedelay { get; init; }

    [XmlElement("watchcat_pinghosts")]
    public required string WatchcatPinghosts { get; init; }

    [XmlElement("watchcat_pingperiod")]
    public required string WatchcatPingperiod { get; init; }

    [XmlElement("webui_mode")]
    public required string WebuiMode { get; init; }

    [XmlElement("automaterial")]
    public bool Automaterial { get; init; }

    [XmlElement("search")]
    public required string Search { get; init; }

    [XmlElement("main_bg")]
    public bool MainBg { get; init; }

    [XmlElement("force_new")]
    public required string ForceNew { get; init; }

    [XmlElement("force_old")]
    public required string ForceOld { get; init; }

    [XmlElement("force_both")]
    public required string ForceBoth { get; init; }

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