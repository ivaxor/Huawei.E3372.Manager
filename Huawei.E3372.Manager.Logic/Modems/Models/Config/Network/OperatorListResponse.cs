using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Config.Network;

[XmlRoot("OperatorList")]
public record OperatorListResponse : IModemGetResponse
{
    [XmlElement("Item")]
    public OperatorListItem[] Items { get; set; }
}

public record OperatorListItem
{
    [XmlAttribute("plmn")]
    public string Plmn { get; set; }

    [XmlAttribute("shortdescr")]
    public string ShortDescription { get; set; }

    [XmlAttribute("picture")]
    public string Picture { get; set; }
}
