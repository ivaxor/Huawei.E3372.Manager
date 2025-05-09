using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Pin;

[XmlRoot("response")]
public record PinStatusResponse : IModemGetResponse
{
    [XmlElement("SimState")]
    public required int SimState { get; init; }

    [XmlElement("PinOptState")]
    public required int PinOptState { get; init; }

    [XmlElement("SimPinTimes")]
    public required int SimPinTimes { get; init; }

    [XmlElement("SimPukTimes")]
    public required int SimPukTimes { get; init; }
}