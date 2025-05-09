using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Config.Ussd;

[XmlRoot("config")]
public record PrePaidUssd : IModemGetResponse
{
    [XmlElement("USSD")]
    public PrePaidUssdElement USSD { get; init; }
}

public record PrePaidUssdElement
{
    [XmlElement("ActivateInternetService")]
    public PrePaidUssdActivateInternetService ActivateInternetService { get; init; }

    [XmlElement("BalanceInquiry")]
    public PrePaidUssdBalanceInquiry BalanceInquiry { get; init; }

    [XmlElement("Charge")]
    public PrePaidUssdCharge Charge { get; init; }

    [XmlElement("General")]
    public PrePaidUssdGeneral General { get; init; }
}

public record PrePaidUssdActivateInternetService
{
    [XmlElement("Title")]
    public string? Title { get; init; }

    [XmlElement("Description")]
    public string? Description { get; init; }

    [XmlElement("Items")]
    public List<PrePaidUssdItem> Items { get; init; }
}

public record PrePaidUssdBalanceInquiry
{
    [XmlElement("Title")]
    public string? Title { get; init; }

    [XmlElement("Items")]
    public List<PrePaidUssdItem> Items { get; init; }
}

public record PrePaidUssdCharge
{
    [XmlElement("Title")]
    public string? Title { get; init; }

    [XmlElement("Items")]
    public List<PrePaidUssdChargeItem> Items { get; init; }
}

public record PrePaidUssdGeneral
{
    [XmlElement("Title")]
    public string? Title { get; init; }

    [XmlElement("Description")]
    public string? Description { get; init; }

    [XmlElement("LimitText")]
    public string? LimitText { get; init; }

    [XmlElement("Menu")]
    public string? Menu { get; init; }

    [XmlElement("NewMenu")]
    public string? NewMenu { get; init; }

    [XmlElement("RussianMenu")]
    public string? RussianMenu { get; init; }

    [XmlElement("RussianNewMenu")]
    public string? RussianNewMenu { get; init; }

    [XmlElement("Action")]
    public string? Action { get; init; }
}

public record PrePaidUssdItem
{
    [XmlElement("Subject")]
    public string? Subject { get; init; }

    [XmlElement("Action")]
    public string? Action { get; init; }

    [XmlElement("Command")]
    public string? Command { get; init; }
}

public record PrePaidUssdChargeItem : PrePaidUssdItem
{
    [XmlElement("Description")]
    public string? Description { get; init; }

    [XmlElement("LimitText")]
    public string? LimitText { get; init; }
}