using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Net;

[XmlRoot("response")]
public record NetModeResponse : IModemGetResponse
{
    [XmlElement("NetworkMode")]
    public string NetworkMode { get; init; }

    [XmlElement("NetworkBand")]
    public string NetworkBand { get; init; }

    [XmlElement("LTEBand")]
    public string LTEBand { get; init; }
}