using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Stk;

[XmlRoot("response")]
public record StkGetMainResponse : IModemPostResponse
{
    [XmlElement("CmdType")]
    public required int CmdType { get; init; }

    [XmlElement("CmdIndex")]
    public required int CmdIndex { get; init; }

    [XmlElement("IsTimeout")]
    public required int IsTimeout { get; init; }

    [XmlElement("DataTotal")]
    public required int DataTotal { get; init; }

    [XmlElement("PageTotal")]
    public required int PageTotal { get; init; }

    [XmlElement("PageIndex")]
    public required int PageIndex { get; init; }

    [XmlElement("STKData")]
    public required StkGetMainData Data { get; init; }
}

public record StkGetMainData
{
    [XmlElement("Field")]
    public required StkGetMainDataField[] Fields { get; init; }
}

public record StkGetMainDataField
{
    [XmlElement("Value")]
    public required string Value { get; init; }

    [XmlElement("Name")]
    public required string Name { get; init; }
}
