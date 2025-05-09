using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Config.Ussd;

[XmlRoot("config")]
public record PrePaidUssdResponse : IModemGetResponse
{
    [XmlElement("USSD")]
    public required PrePaidUssd USSD { get; init; }
}

public record PrePaidUssd
{
    [XmlElement("ActivateInternetService")]
    public required PrePaidUssdActivateInternetService ActivateInternetService { get; init; }

    [XmlElement("BalanceInquiry")]
    public required PrePaidUssdBalanceInquiry BalanceInquiry { get; init; }

    [XmlElement("Charge")]
    public required PrePaidUssdCharge Charge { get; init; }

    [XmlElement("General")]
    public required PrePaidUssdGeneral General { get; init; }
}

public record PrePaidUssdActivateInternetService
{
    [XmlElement("Title")]
    public required string Title { get; init; }

    [XmlElement("Description")]
    public required string Description { get; init; }

    [XmlElement("Items")]
    public required PrePaidUssdItem[] Items { get; init; }
}

public record PrePaidUssdBalanceInquiry
{
    [XmlElement("Title")]
    public required string Title { get; init; }

    [XmlElement("Items")]
    public required PrePaidUssdItem[] Items { get; init; }
}

public record PrePaidUssdCharge
{
    [XmlElement("Title")]
    public required string Title { get; init; }

    [XmlElement("Items")]
    public required PrePaidUssdChargeItem[] Items { get; init; }
}

public record PrePaidUssdGeneral
{
    [XmlElement("Title")]
    public required string Title { get; init; }

    [XmlElement("Description")]
    public required string Description { get; init; }

    [XmlElement("LimitText")]
    public required string LimitText { get; init; }

    [XmlElement("Menu")]
    public required string Menu { get; init; }

    [XmlElement("NewMenu")]
    public required string NewMenu { get; init; }

    [XmlElement("RussianMenu")]
    public required string RussianMenu { get; init; }

    [XmlElement("RussianNewMenu")]
    public required string RussianNewMenu { get; init; }

    [XmlElement("Action")]
    public required string Action { get; init; }
}

public record PrePaidUssdItem
{
    [XmlElement("Subject")]
    public required string Subject { get; init; }

    [XmlElement("Action")]
    public required string Action { get; init; }

    [XmlElement("Command")]
    public required string Command { get; init; }
}

public record PrePaidUssdChargeItem : PrePaidUssdItem
{
    [XmlElement("Description")]
    public required string Description { get; init; }

    [XmlElement("LimitText")]
    public required string LimitText { get; init; }
}