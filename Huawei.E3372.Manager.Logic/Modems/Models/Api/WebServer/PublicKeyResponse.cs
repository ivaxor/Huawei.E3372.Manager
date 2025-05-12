using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.WebServer;

[XmlRoot("response")]
public record PublicKeyResponse : IModemGetResponse
{
    [XmlElement("encpubkeyn")]
    public string EncPublicKey { get; set; }

    [XmlElement("encpubkeye")]
    public string EncPublicEye { get; set; }
}