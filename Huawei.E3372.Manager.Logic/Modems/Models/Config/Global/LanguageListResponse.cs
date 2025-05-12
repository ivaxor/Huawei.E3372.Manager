using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Config.Global;

[XmlRoot("config")]
public record LanguageListResponse : IModemGetResponse
{
    [XmlElement("languages")]
    public LanguageListLanguages Languages { get; set; }

    [XmlElement("privacy_policy_url")]
    public LanguageListPrivacyPolicyUrl PrivacyPolicyUrl { get; set; }

    [XmlElement("usermanual_language")]
    public LanguageListUserManual UserManual { get; set; }
}

public record LanguageListLanguages
{
    [XmlElement("language")]
    public string[] Languages { get; set; }
}

public record LanguageListPrivacyPolicyUrl
{
    [XmlElement("default_url")]
    public string DefaultUrl { get; set; }

    [XmlElement("en_us")]
    public string EnUs { get; set; }

    [XmlElement("zh_cn")]
    public string ZhCn { get; set; }

    [XmlElement("ar_sa")]
    public string ArSa { get; set; }

    [XmlElement("pt_br")]
    public string PtBr { get; set; }

    [XmlElement("bg_bg")]
    public string BgBg { get; set; }

    [XmlElement("hr_hr")]
    public string HrHr { get; set; }

    [XmlElement("cs_cz")]
    public string CsCz { get; set; }

    [XmlElement("da_dk")]
    public string DaDk { get; set; }

    [XmlElement("nl_nl")]
    public string NlNl { get; set; }

    [XmlElement("et_ee")]
    public string EtEe { get; set; }

    [XmlElement("fa_fa")]
    public string FaFa { get; set; }

    [XmlElement("fi_fi")]
    public string FiFi { get; set; }

    [XmlElement("fr_fr")]
    public string FrFr { get; set; }

    [XmlElement("de_de")]
    public string DeDe { get; set; }

    [XmlElement("el_gr")]
    public string ElGr { get; set; }

    [XmlElement("hu_hu")]
    public string HuHu { get; set; }

    [XmlElement("he_il")]
    public string HeIl { get; set; }

    [XmlElement("id_id")]
    public string IdId { get; set; }

    [XmlElement("it_it")]
    public string ItIt { get; set; }

    [XmlElement("ja_jp")]
    public string JaJp { get; set; }

    [XmlElement("ko_kr")]
    public string KoKr { get; set; }

    [XmlElement("lv_lv")]
    public string LvLv { get; set; }

    [XmlElement("lt_lt")]
    public string LtLt { get; set; }

    [XmlElement("mk_mk")]
    public string MkMk { get; set; }

    [XmlElement("no_no")]
    public string NoNo { get; set; }

    [XmlElement("pl_pl")]
    public string PlPl { get; set; }

    [XmlElement("pt_pt")]
    public string PtPt { get; set; }

    [XmlElement("ro_ro")]
    public string RoRo { get; set; }

    [XmlElement("ru_ru")]
    public string RuRu { get; set; }

    [XmlElement("sr_cs")]
    public string SrCs { get; set; }

    [XmlElement("sk_sk")]
    public string SkSk { get; set; }

    [XmlElement("sl_sl")]
    public string SlSl { get; set; }

    [XmlElement("es_es")]
    public string EsEs { get; set; }

    [XmlElement("es_ar")]
    public string EsAr { get; set; }

    [XmlElement("sv_se")]
    public string SvSe { get; set; }

    [XmlElement("zh_tw")]
    public string ZhTw { get; set; }

    [XmlElement("zh_hk")]
    public string ZhHk { get; set; }

    [XmlElement("tr_tr")]
    public string TrTr { get; set; }

    [XmlElement("uk_ua")]
    public string UkUa { get; set; }

    [XmlElement("vi_vn")]
    public string ViVn { get; set; }
}

public record LanguageListUserManual
{
    [XmlElement("default_language")]
    public string DefaultLanguage { get; set; }

    [XmlElement("support_language")]
    public LanguageListUserManualSupport Support { get; set; }
}

public record LanguageListUserManualSupport
{
    [XmlElement("language")]
    public string[] Languages { get; set; }
}