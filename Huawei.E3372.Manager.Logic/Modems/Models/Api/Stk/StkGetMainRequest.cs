using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Stk;

[XmlRoot("request")]
public record StkGetMain2Request : IModemPostRequest
{
    [XmlElement("CmdType")]
    public int CmdType { get; init; }

    [XmlElement("CmdIndex")]
    public int CmdIndex { get; init; }

    [XmlElement("Result")]
    public int Result { get; init; }

    [XmlElement("DataType")]
    public int DataType { get; init; }

    [XmlElement("Data")]
    public int Data { get; init; }

    [XmlElement("MenuLevel")]
    public int MenuLevel { get; init; }

    [XmlElement("PageIndex")]
    public int PageIndex { get; init; }

    [XmlElement("ReadCount")]
    public int ReadCount { get; init; }

    [XmlElement("IsJumpPage")]
    public bool IsJumpPage { get; init; }
}