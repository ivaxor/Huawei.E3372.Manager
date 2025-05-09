using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Pb;

[XmlRoot("response")]
public record PbCount : IModemGetResponse
{
    [XmlElement("LocalUsed")]
    public int LocalUsed { get; init; }

    [XmlElement("SimUsed")]
    public int SimUsed { get; init; }

    [XmlElement("LocalMax")]
    public int LocalMax { get; init; }

    [XmlElement("SimMax")]
    public int SimMax { get; init; }
}