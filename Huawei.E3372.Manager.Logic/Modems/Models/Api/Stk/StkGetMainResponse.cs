using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Stk;

[XmlRoot("response")]
public record StkGetMainResponse : IModemPostResponse
{
    [XmlElement("CmdType")]
    public int CmdType { get; init; }

    [XmlElement("CmdIndex")]
    public int CmdIndex { get; init; }

    [XmlElement("IsTimeout")]
    public int IsTimeout { get; init; }

    [XmlElement("DataTotal")]
    public int DataTotal { get; init; }

    [XmlElement("PageTotal")]
    public int PageTotal { get; init; }

    [XmlElement("PageIndex")]
    public int PageIndex { get; init; }

    [XmlElement("STKData")]
    public StkGetMainData Data { get; init; }
}

public record StkGetMainData
{
    [XmlElement("Field")]
    public StkGetMainDataField[] Fields { get; init; }
}

public record StkGetMainDataField
{
    [XmlElement("Value")]
    public string Value { get; init; }

    [XmlElement("Name")]
    public string Name { get; init; }
}
