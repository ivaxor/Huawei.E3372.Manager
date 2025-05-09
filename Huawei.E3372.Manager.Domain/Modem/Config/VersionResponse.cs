using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Config;

[XmlRoot("config")]
public record VersionResponse : IModemGetResponse
{
    [XmlElement("webui")]
    public string? WebUi { get; init; }
}