using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Net;

[XmlRoot("response")]
public record SignalParaResponse : IModemGetResponse
{
    [XmlElement("Rscp")]
    public required int Rscp { get; init; }

    [XmlElement("Ecio")]
    public required int Ecio { get; init; }
}