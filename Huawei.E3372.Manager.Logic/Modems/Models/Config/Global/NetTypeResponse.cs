using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Config.Global;

[XmlRoot("config")]
public record NetTypeResponse : IModemGetResponse
{
    [XmlElement("networktypes")]
    public NetTypeElement[] NetworkTypes { get; init; }
}

public record NetTypeElement
{
    [XmlElement("index")]
    public string Index { get; init; }

    [XmlElement("networktype")]
    public string NetworkType { get; init; }
}