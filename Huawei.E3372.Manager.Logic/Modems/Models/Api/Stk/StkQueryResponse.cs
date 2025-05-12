using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Stk;

[XmlRoot("response")]
public record StkQueryResponse : IModemGetResponse
{
    [XmlElement("CmdType")]
    public int CmdType { get; set; }

    [XmlElement("CmdIndex")]
    public int CmdIndex { get; set; }

    [XmlElement("IsTimeout")]
    public bool IsTimeout { get; set; }

    [XmlElement("STKData")]
    public StkQueryData Data { get; set; }
}

public record StkQueryData { }