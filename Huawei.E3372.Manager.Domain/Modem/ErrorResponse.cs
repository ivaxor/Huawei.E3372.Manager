using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem;

[XmlRoot("error")]
public record Error : IModemResponse
{
    [XmlElement("code")]
    public int Code { get; init; }

    [XmlElement("message")]
    public string? Message { get; init; }
}