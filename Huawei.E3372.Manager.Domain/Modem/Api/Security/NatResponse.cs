using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Security;

[XmlRoot("response")]
public record NatResponse : IModemGetResponse
{
    [XmlElement("NATType")]
    public required int NATType { get; init; }
}