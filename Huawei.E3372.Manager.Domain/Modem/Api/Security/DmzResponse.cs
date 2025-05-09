using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Security;

[XmlRoot("response")]
public record DmzResponse : IModemGetResponse
{
    [XmlElement("DmzStatus")]
    public required bool DmzStatus { get; init; }

    [XmlElement("DmzIPAddress")]
    public required string DmzIPAddress { get; init; }
}