using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.WebServer;

[XmlRoot("response")]
public record PublicKeyResponse : IModemGetResponse
{
    [XmlElement("encpubkeyn")]
    public required string EncPublicKey { get; init; }

    [XmlElement("encpubkeye")]
    public required string EncPublicEye { get; init; }
}