using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Config.Global;

[XmlRoot("config")]
public record NetTypeResponse : IModemGetResponse
{
    [XmlElement("networktypes")]
    public required NetTypeElement[] NetworkTypes { get; init; }
}

public record NetTypeElement
{
    [XmlElement("index")]
    public required string Index { get; init; }

    [XmlElement("networktype")]
    public required string NetworkType { get; init; }
}