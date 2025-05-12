using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Config.Ussd;

[XmlRoot("config")]
public record PrePaidUssdResponse : IModemGetResponse
{
    [XmlElement("USSD")]
    public PrePaidUssd USSD { get; set; }
}

public record PrePaidUssd
{
    [XmlElement("ActivateInternetService")]
    public PrePaidUssdActivateInternetService ActivateInternetService { get; set; }

    [XmlElement("BalanceInquiry")]
    public PrePaidUssdBalanceInquiry BalanceInquiry { get; set; }

    [XmlElement("Charge")]
    public PrePaidUssdCharge Charge { get; set; }

    [XmlElement("General")]
    public PrePaidUssdGeneral General { get; set; }
}

public record PrePaidUssdActivateInternetService
{
    [XmlElement("Title")]
    public string Title { get; set; }

    [XmlElement("Description")]
    public string Description { get; set; }

    [XmlElement("Items")]
    public PrePaidUssdItem[] Items { get; set; }
}

public record PrePaidUssdBalanceInquiry
{
    [XmlElement("Title")]
    public string Title { get; set; }

    [XmlElement("Items")]
    public PrePaidUssdItem[] Items { get; set; }
}

public record PrePaidUssdCharge
{
    [XmlElement("Title")]
    public string Title { get; set; }

    [XmlElement("Items")]
    public PrePaidUssdChargeItem[] Items { get; set; }
}

public record PrePaidUssdGeneral
{
    [XmlElement("Title")]
    public string Title { get; set; }

    [XmlElement("Description")]
    public string Description { get; set; }

    [XmlElement("LimitText")]
    public string LimitText { get; set; }

    [XmlElement("Menu")]
    public string Menu { get; set; }

    [XmlElement("NewMenu")]
    public string NewMenu { get; set; }

    [XmlElement("RussianMenu")]
    public string RussianMenu { get; set; }

    [XmlElement("RussianNewMenu")]
    public string RussianNewMenu { get; set; }

    [XmlElement("Action")]
    public string Action { get; set; }
}

public record PrePaidUssdItem
{
    [XmlElement("Subject")]
    public string Subject { get; set; }

    [XmlElement("Action")]
    public string Action { get; set; }

    [XmlElement("Command")]
    public string Command { get; set; }
}

public record PrePaidUssdChargeItem : PrePaidUssdItem
{
    [XmlElement("Description")]
    public string Description { get; set; }

    [XmlElement("LimitText")]
    public string LimitText { get; set; }
}