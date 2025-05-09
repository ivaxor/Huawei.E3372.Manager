using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Security;

[XmlRoot("response")]
public record SipResponse : IModemGetResponse
{
    [XmlElement("SipStatus")]
    public required bool SipStatus { get; init; }

    [XmlElement("SipPort")]
    public required int SipPort { get; init; }
}