using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Pin;

[XmlRoot("response")]
public record SavePinResponse : IModemGetResponse
{
    [XmlElement("SimSavepinStatus")]
    public required int SimSavePinStatus { get; init; }

    [XmlElement("SimSavepinScid")]
    public required string SimSavePinScid { get; init; }

    [XmlElement("simsavepinenable")]
    public required bool SimSavePinEnable { get; init; }
}