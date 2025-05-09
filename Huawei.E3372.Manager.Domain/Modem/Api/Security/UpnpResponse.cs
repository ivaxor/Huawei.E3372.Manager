using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Security;

[XmlRoot("response")]
public record UpnpResponse : IModemGetResponse
{
    [XmlElement("UpnpStatus")]
    public required bool UpnpStatus { get; init; }
}