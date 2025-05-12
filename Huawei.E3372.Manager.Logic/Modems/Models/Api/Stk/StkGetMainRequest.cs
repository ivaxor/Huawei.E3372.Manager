using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Stk;

[XmlRoot("request")]
public record StkGetMain2Request : IModemPostRequest
{
    [XmlElement("CmdType")]
    public int CmdType { get; set; }

    [XmlElement("CmdIndex")]
    public int CmdIndex { get; set; }

    [XmlElement("Result")]
    public int Result { get; set; }

    [XmlElement("DataType")]
    public int DataType { get; set; }

    [XmlElement("Data")]
    public int Data { get; set; }

    [XmlElement("MenuLevel")]
    public int MenuLevel { get; set; }

    [XmlElement("PageIndex")]
    public int PageIndex { get; set; }

    [XmlElement("ReadCount")]
    public int ReadCount { get; set; }

    [XmlElement("IsJumpPage")]
    public bool IsJumpPage { get; set; }
}