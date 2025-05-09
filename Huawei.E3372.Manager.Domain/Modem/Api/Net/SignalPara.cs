using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Net;

[XmlRoot("response")]
public record SignalPara : IModemGetResponse
{
    [XmlElement("Rscp")]
    public int Rscp { get; init; }

    [XmlElement("Ecio")]
    public int Ecio { get; init; }
}