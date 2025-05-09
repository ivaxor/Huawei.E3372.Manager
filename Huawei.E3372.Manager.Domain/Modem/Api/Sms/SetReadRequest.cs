using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Sms;

[XmlRoot("request")]
public record SetReadRequest : IModemPostRequest
{
    [XmlElement("Index")]
    public required bool Index { get; init; }
}