using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Net;

[XmlRoot("response")]
public record NetFeatureSwitchReponse : IModemGetResponse
{
    [XmlElement("net_premode_switch")]
    public int NetPremodeSwitch { get; init; }
}