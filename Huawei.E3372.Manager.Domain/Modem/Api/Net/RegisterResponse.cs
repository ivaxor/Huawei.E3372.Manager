using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Net;

[XmlRoot("response")]
public record RegisterResponse : IModemGetResponse
{
    [XmlElement("Mode")]
    public required int Mode { get; init; }

    [XmlElement("Plmn")]
    public required string Plmn { get; init; }

    [XmlElement("Rat")]
    public required string Rat { get; init; }
}