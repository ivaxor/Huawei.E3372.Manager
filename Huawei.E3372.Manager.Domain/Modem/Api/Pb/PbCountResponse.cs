using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Pb;

[XmlRoot("response")]
public record PbCountResponse : IModemGetResponse
{
    [XmlElement("LocalUsed")]
    public required int LocalUsed { get; init; }

    [XmlElement("SimUsed")]
    public required int SimUsed { get; init; }

    [XmlElement("LocalMax")]
    public required int LocalMax { get; init; }

    [XmlElement("SimMax")]
    public required int SimMax { get; init; }
}