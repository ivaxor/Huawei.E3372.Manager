using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Stk;

[XmlRoot("request")]
public record StkGetMain2Request : IModemPostRequest
{
    [XmlElement("CmdType")]
    public required int CmdType { get; init; }

    [XmlElement("CmdIndex")]
    public required int CmdIndex { get; init; }

    [XmlElement("Result")]
    public required int Result { get; init; }

    [XmlElement("DataType")]
    public required int DataType { get; init; }

    [XmlElement("Data")]
    public required int Data { get; init; }

    [XmlElement("MenuLevel")]
    public required int MenuLevel { get; init; }

    [XmlElement("PageIndex")]
    public required int PageIndex { get; init; }

    [XmlElement("ReadCount")]
    public required int ReadCount { get; init; }

    [XmlElement("IsJumpPage")]
    public required bool IsJumpPage { get; init; }
}