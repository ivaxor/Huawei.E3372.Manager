using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Net;

[XmlRoot("response")]
public record NetFeatureSwitchReponse : IModemGetResponse
{
    [XmlElement("net_premode_switch")]
    public required int NetPremodeSwitch { get; init; }
}