using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Pin;

[XmlRoot("response")]
public record SavePinResponse : IModemGetResponse
{
    [XmlElement("SimSavepinStatus")]
    public int SimSavePinStatus { get; set; }

    [XmlElement("SimSavepinScid")]
    public string SimSavePinScid { get; set; }

    [XmlElement("simsavepinenable")]
    public bool SimSavePinEnable { get; set; }
}