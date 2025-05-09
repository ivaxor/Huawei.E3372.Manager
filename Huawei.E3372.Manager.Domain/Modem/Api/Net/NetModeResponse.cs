using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Net;

[XmlRoot("response")]
public record NetModeResponse : IModemGetResponse
{
    [XmlElement("NetworkMode")]
    public required string NetworkMode { get; init; }

    [XmlElement("NetworkBand")]
    public required string NetworkBand { get; init; }

    [XmlElement("LTEBand")]
    public required string LTEBand { get; init; }
}