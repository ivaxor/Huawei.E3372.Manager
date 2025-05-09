using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem;

[XmlRoot("config")]
public record UserConfigResponse : IModemGetResponse
{

    [XmlElement("datalock")]
    public required string DataLock { get; init; }

    [XmlElement("autounlock")]
    public required bool AutoUnlock { get; init; }

    [XmlElement("pinautovalidate")]
    public required string PinAutoValidate { get; init; }

    [XmlElement("imei_generator_model")]
    public required string ImeiGeneratorModel { get; init; }

    [XmlElement("backup_imei")]
    public required string BackupImei { get; init; }

    [XmlElement("autorun_imei_generator")]
    public required bool AutoRunImeiGenerator { get; init; }

    [XmlElement("autoimei")]
    public required bool AutoImei { get; init; }

    [XmlElement("hspa_locker")]
    public required bool HspaLocker { get; init; }

    [XmlElement("add_param")]
    public required bool AddParam { get; init; }

    [XmlElement("operator")]
    public required bool Operator { get; init; }

    [XmlElement("websd")]
    public required bool Websd { get; init; }

    [XmlElement("watchcat")]
    public required bool Watchcat { get; init; }

    [XmlElement("watchcat_mode")]
    public required string WatchcatMode { get; init; }

    [XmlElement("watchcat_period")]
    public required string WatchcatPeriod { get; init; }

    [XmlElement("watchcat_forcedelay")]
    public required int WatchcatForceDelay { get; init; }

    [XmlElement("watchcat_pinghosts")]
    public required string WatchcatPingHosts { get; init; }

    [XmlElement("watchcat_pingperiod")]
    public required string WatchcatPingPeriod { get; init; }

    [XmlElement("webui_mode")]
    public required string WebuiMode { get; init; }

    [XmlElement("automaterial")]
    public required bool AutoMaterial { get; init; }

    [XmlElement("search")]
    public required string Search { get; init; }

    [XmlElement("main_bg")]
    public required bool MainBg { get; init; }

    [XmlElement("force_new")]
    public required string ForceNew { get; init; }

    [XmlElement("force_old")]
    public required string ForceOld { get; init; }

    [XmlElement("force_both")]
    public required string ForceBoth { get; init; }

    [XmlElement("force_new_home")]
    public required bool ForceNewHome { get; init; }

    [XmlElement("force_old_home")]
    public required bool ForceOldHome { get; init; }

    [XmlElement("force_new_statistic")]
    public required bool ForceNewStatistic { get; init; }

    [XmlElement("force_old_statistic")]
    public required bool ForceOldStatistic { get; init; }

    [XmlElement("force_both_statistic")]
    public required bool ForceBothStatistic { get; init; }

    [XmlElement("force_new_sms")]
    public required bool ForceNewSms { get; init; }

    [XmlElement("force_old_sms")]
    public required bool ForceOldSms { get; init; }

    [XmlElement("force_new_ussd")]
    public required bool ForceNewUssd { get; init; }

    [XmlElement("force_old_ussd")]
    public required bool ForceOldUssd { get; init; }
}