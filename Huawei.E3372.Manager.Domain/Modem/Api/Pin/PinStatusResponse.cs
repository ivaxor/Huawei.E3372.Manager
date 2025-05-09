using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Pin;

[XmlRoot("response")]
public record PinStatusResponse : IModemGetResponse
{
    [XmlElement("SimState")]
    public int SimState { get; init; }

    [XmlElement("PinOptState")]
    public int PinOptState { get; init; }

    [XmlElement("SimPinTimes")]
    public int SimPinTimes { get; init; }

    [XmlElement("SimPukTimes")]
    public int SimPukTimes { get; init; }
}