using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Config.Global;

[XmlRoot("config")]
public record NetType : IModemGetResponse
{
    [XmlElement("networktypes")]
    public List<NetTypeElement> NetworkTypes { get; init; }
}

public record NetTypeElement
{
    [XmlElement("index")]
    public string Index { get; init; }

    [XmlElement("networktype")]
    public string NetworkType { get; init; }
}