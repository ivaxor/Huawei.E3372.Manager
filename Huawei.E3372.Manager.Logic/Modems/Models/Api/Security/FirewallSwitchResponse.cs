using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Security;

[XmlRoot("response")]
public record FirewallSwitchResponse : IModemGetResponse
{
    [XmlElement("FirewallMainSwitch")]
    public bool FirewallMainSwitch { get; set; }

    [XmlElement("FirewallIPFilterSwitch")]
    public bool FirewallIPFilterSwitch { get; set; }

    [XmlElement("FirewallWanPortPingSwitch")]
    public bool FirewallWanPortPingSwitch { get; set; }
}