using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Config.Network;

[XmlRoot("OperatorList")]
public record OperatorListResponse : IModemGetResponse
{
    [XmlElement("Item")]
    public OperatorListItem[] Items { get; init; }
}

public record OperatorListItem
{
    [XmlAttribute("plmn")]
    public string Plmn { get; init; }

    [XmlAttribute("shortdescr")]
    public string ShortDescription { get; init; }

    [XmlAttribute("picture")]
    public string Picture { get; init; }
}
