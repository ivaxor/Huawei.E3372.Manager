using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.WebServer;

[XmlRoot("response")]
public record SessionTokenInfo : IModemGetResponse
{
    [XmlElement("SesInfo")]

    public string? SessionInfo { get; init; }

    [XmlElement("TokInfo")]
    public string? TokenInfo { get; init; }
}