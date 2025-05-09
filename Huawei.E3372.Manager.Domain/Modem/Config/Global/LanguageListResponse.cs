using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Config.Global;

[XmlRoot("config")]
public record LanguageListResponse : IModemGetResponse
{
    [XmlElement("languages")]
    public LanguageListLanguages Languages { get; init; }

    [XmlElement("privacy_policy_url")]
    public LanguageListPrivacyPolicyUrl PrivacyPolicyUrl { get; init; }

    [XmlElement("usermanual_language")]
    public LanguageListUserManual UserManual { get; init; }
}

public record LanguageListLanguages
{
    [XmlElement("language")]
    public List<string> Language { get; init; }
}

public record LanguageListPrivacyPolicyUrl
{
    [XmlElement("default_url")]
    public string DefaultUrl { get; init; }

    [XmlElement("en_us")]
    public string EnUs { get; init; }

    [XmlElement("zh_cn")]
    public string ZhCn { get; init; }

    [XmlElement("ar_sa")]
    public string ArSa { get; init; }

    [XmlElement("pt_br")]
    public string PtBr { get; init; }

    [XmlElement("bg_bg")]
    public string BgBg { get; init; }

    [XmlElement("hr_hr")]
    public string HrHr { get; init; }

    [XmlElement("cs_cz")]
    public string CsCz { get; init; }

    [XmlElement("da_dk")]
    public string DaDk { get; init; }

    [XmlElement("nl_nl")]
    public string NlNl { get; init; }

    [XmlElement("et_ee")]
    public string EtEe { get; init; }

    [XmlElement("fa_fa")]
    public string FaFa { get; init; }

    [XmlElement("fi_fi")]
    public string FiFi { get; init; }

    [XmlElement("fr_fr")]
    public string FrFr { get; init; }

    [XmlElement("de_de")]
    public string DeDe { get; init; }

    [XmlElement("el_gr")]
    public string ElGr { get; init; }

    [XmlElement("hu_hu")]
    public string HuHu { get; init; }

    [XmlElement("he_il")]
    public string HeIl { get; init; }

    [XmlElement("id_id")]
    public string IdId { get; init; }

    [XmlElement("it_it")]
    public string ItIt { get; init; }

    [XmlElement("ja_jp")]
    public string JaJp { get; init; }

    [XmlElement("ko_kr")]
    public string KoKr { get; init; }

    [XmlElement("lv_lv")]
    public string LvLv { get; init; }

    [XmlElement("lt_lt")]
    public string LtLt { get; init; }

    [XmlElement("mk_mk")]
    public string MkMk { get; init; }

    [XmlElement("no_no")]
    public string NoNo { get; init; }

    [XmlElement("pl_pl")]
    public string PlPl { get; init; }

    [XmlElement("pt_pt")]
    public string PtPt { get; init; }

    [XmlElement("ro_ro")]
    public string RoRo { get; init; }

    [XmlElement("ru_ru")]
    public string RuRu { get; init; }

    [XmlElement("sr_cs")]
    public string SrCs { get; init; }

    [XmlElement("sk_sk")]
    public string SkSk { get; init; }

    [XmlElement("sl_sl")]
    public string SlSl { get; init; }

    [XmlElement("es_es")]
    public string EsEs { get; init; }

    [XmlElement("es_ar")]
    public string EsAr { get; init; }

    [XmlElement("sv_se")]
    public string SvSe { get; init; }

    [XmlElement("zh_tw")]
    public string ZhTw { get; init; }

    [XmlElement("zh_hk")]
    public string ZhHk { get; init; }

    [XmlElement("tr_tr")]
    public string TrTr { get; init; }

    [XmlElement("uk_ua")]
    public string UkUa { get; init; }

    [XmlElement("vi_vn")]
    public string ViVn { get; init; }
}

public record LanguageListUserManual
{
    [XmlElement("default_language")]
    public string DefaultLanguage { get; init; }

    [XmlElement("support_language")]
    public LanguageListUserManualSupport Support { get; init; }
}

public record LanguageListUserManualSupport
{
    [XmlElement("language")]
    public List<string> Language { get; init; }
}