using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.WebServer;

[XmlRoot("response")]
public record PublicKeyResponse : IModemGetResponse
{
    [XmlElement("encpubkeyn")]
    public string? EncPublicKey { get; init; }

    [XmlElement("encpubkeye")]
    public string? EncPublicEye { get; init; }
}