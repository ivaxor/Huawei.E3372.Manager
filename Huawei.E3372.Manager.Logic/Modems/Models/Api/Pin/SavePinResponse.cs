using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Pin;

[XmlRoot("response")]
public record SavePinResponse : IModemGetResponse
{
    [XmlElement("SimSavepinStatus")]
    public int SimSavePinStatus { get; init; }

    [XmlElement("SimSavepinScid")]
    public string SimSavePinScid { get; init; }

    [XmlElement("simsavepinenable")]
    public bool SimSavePinEnable { get; init; }
}