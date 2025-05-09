using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Pb;

[XmlRoot("response")]
public record PbMatchResponse : IModemPostResponse
{
    [XmlElement("Name")]
    public List<string?> Name { get; init; }
}