using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem;

[XmlRoot("response")]
public record DeviceNameResponse : IModemGetResponse
{
    [XmlElement("DeviceName")]
    public required string Name { get; init; }
}