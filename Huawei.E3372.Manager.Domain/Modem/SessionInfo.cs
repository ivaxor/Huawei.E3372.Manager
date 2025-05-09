using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem;

[XmlRoot("response")]
public record SessionTokenInfo : IModemResponse
{
    [XmlElement("SesInfo")]

    public string? SessionInfo { get; init; }

    [XmlElement("TokInfo")]
    public string? TokenInfo { get; init; }
}