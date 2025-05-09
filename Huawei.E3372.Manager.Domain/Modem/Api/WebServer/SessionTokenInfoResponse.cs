using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.WebServer;

[XmlRoot("response")]
public record SessionTokenInfoResponse : IModemGetResponse
{
    [XmlElement("SesInfo")]

    public required string SessionInfo { get; init; }

    [XmlElement("TokInfo")]
    public required string TokenInfo { get; init; }
}