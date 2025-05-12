using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Pin;

[XmlRoot("response")]
public record PinStatusResponse : IModemGetResponse
{
    [XmlElement("SimState")]
    public int SimState { get; set; }

    [XmlElement("PinOptState")]
    public int PinOptState { get; set; }

    [XmlElement("SimPinTimes")]
    public int SimPinTimes { get; set; }

    [XmlElement("SimPukTimes")]
    public int SimPukTimes { get; set; }
}