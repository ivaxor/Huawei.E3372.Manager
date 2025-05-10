using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Stk;

[XmlRoot("response")]
public record StkQueryResponse : IModemGetResponse
{
    [XmlElement("CmdType")]
    public int CmdType { get; init; }

    [XmlElement("CmdIndex")]
    public int CmdIndex { get; init; }

    [XmlElement("IsTimeout")]
    public bool IsTimeout { get; init; }

    [XmlElement("STKData")]
    public StkQueryData Data { get; init; }
}

public record StkQueryData { }