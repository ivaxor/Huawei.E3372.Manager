using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Config.Global;

[XmlRoot("config")]
public record LanguageListResponse : IModemGetResponse
{
    [XmlElement("languages")]
    public required LanguageListLanguages Languages { get; init; }

    [XmlElement("privacy_policy_url")]
    public required LanguageListPrivacyPolicyUrl PrivacyPolicyUrl { get; init; }

    [XmlElement("usermanual_language")]
    public required LanguageListUserManual UserManual { get; init; }
}

public record LanguageListLanguages
{
    [XmlElement("language")]
    public required string[] Languages { get; init; }
}

public record LanguageListPrivacyPolicyUrl
{
    [XmlElement("default_url")]
    public required string DefaultUrl { get; init; }

    [XmlElement("en_us")]
    public required string EnUs { get; init; }

    [XmlElement("zh_cn")]
    public required string ZhCn { get; init; }

    [XmlElement("ar_sa")]
    public required string ArSa { get; init; }

    [XmlElement("pt_br")]
    public required string PtBr { get; init; }

    [XmlElement("bg_bg")]
    public required string BgBg { get; init; }

    [XmlElement("hr_hr")]
    public required string HrHr { get; init; }

    [XmlElement("cs_cz")]
    public required string CsCz { get; init; }

    [XmlElement("da_dk")]
    public required string DaDk { get; init; }

    [XmlElement("nl_nl")]
    public required string NlNl { get; init; }

    [XmlElement("et_ee")]
    public required string EtEe { get; init; }

    [XmlElement("fa_fa")]
    public required string FaFa { get; init; }

    [XmlElement("fi_fi")]
    public required string FiFi { get; init; }

    [XmlElement("fr_fr")]
    public required string FrFr { get; init; }

    [XmlElement("de_de")]
    public required string DeDe { get; init; }

    [XmlElement("el_gr")]
    public required string ElGr { get; init; }

    [XmlElement("hu_hu")]
    public required string HuHu { get; init; }

    [XmlElement("he_il")]
    public required string HeIl { get; init; }

    [XmlElement("id_id")]
    public required string IdId { get; init; }

    [XmlElement("it_it")]
    public required string ItIt { get; init; }

    [XmlElement("ja_jp")]
    public required string JaJp { get; init; }

    [XmlElement("ko_kr")]
    public required string KoKr { get; init; }

    [XmlElement("lv_lv")]
    public required string LvLv { get; init; }

    [XmlElement("lt_lt")]
    public required string LtLt { get; init; }

    [XmlElement("mk_mk")]
    public required string MkMk { get; init; }

    [XmlElement("no_no")]
    public required string NoNo { get; init; }

    [XmlElement("pl_pl")]
    public required string PlPl { get; init; }

    [XmlElement("pt_pt")]
    public required string PtPt { get; init; }

    [XmlElement("ro_ro")]
    public required string RoRo { get; init; }

    [XmlElement("ru_ru")]
    public required string RuRu { get; init; }

    [XmlElement("sr_cs")]
    public required string SrCs { get; init; }

    [XmlElement("sk_sk")]
    public required string SkSk { get; init; }

    [XmlElement("sl_sl")]
    public required string SlSl { get; init; }

    [XmlElement("es_es")]
    public required string EsEs { get; init; }

    [XmlElement("es_ar")]
    public required string EsAr { get; init; }

    [XmlElement("sv_se")]
    public required string SvSe { get; init; }

    [XmlElement("zh_tw")]
    public required string ZhTw { get; init; }

    [XmlElement("zh_hk")]
    public required string ZhHk { get; init; }

    [XmlElement("tr_tr")]
    public required string TrTr { get; init; }

    [XmlElement("uk_ua")]
    public required string UkUa { get; init; }

    [XmlElement("vi_vn")]
    public required string ViVn { get; init; }
}

public record LanguageListUserManual
{
    [XmlElement("default_language")]
    public required string DefaultLanguage { get; init; }

    [XmlElement("support_language")]
    public required LanguageListUserManualSupport Support { get; init; }
}

public record LanguageListUserManualSupport
{
    [XmlElement("language")]
    public required string[] Languages { get; init; }
}