using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Sms;

[XmlRoot("response")]
public record SetReadResponse : IModemPostResponse
{
    [XmlText]
    public required string Value { get; init; }
}