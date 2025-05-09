using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Stk;

[XmlRoot("response")]
public record StkQueryResponse : IModemGetResponse
{
    [XmlElement("CmdType")]
    public required int CmdType { get; init; }

    [XmlElement("CmdIndex")]
    public required int CmdIndex { get; init; }

    [XmlElement("IsTimeout")]
    public required bool IsTimeout { get; init; }

    [XmlElement("STKData")]
    public required StkQueryData Data { get; init; }
}

public record StkQueryData { }