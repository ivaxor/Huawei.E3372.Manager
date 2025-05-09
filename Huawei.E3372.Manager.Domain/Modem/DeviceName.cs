using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem;

[XmlRoot("response")]
public record DeviceName : IModemGetResponse
{
    [XmlElement("DeviceName")]
    public string? Name { get; init; }
}