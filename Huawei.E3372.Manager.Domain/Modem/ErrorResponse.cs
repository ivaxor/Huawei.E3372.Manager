using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem;

[XmlRoot("error")]
public record ErrorResponse : IModemGetResponse, IModemPostResponse
{
    [XmlElement("code")]
    public required int Code { get; init; }

    [XmlElement("message")]
    public required string Message { get; init; }
}