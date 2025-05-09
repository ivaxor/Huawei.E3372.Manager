using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Security;

[XmlRoot("response")]
public record FirewallSwitchResponse : IModemGetResponse
{
    [XmlElement("FirewallMainSwitch")]
    public required bool FirewallMainSwitch { get; init; }

    [XmlElement("FirewallIPFilterSwitch")]
    public required bool FirewallIPFilterSwitch { get; init; }

    [XmlElement("FirewallWanPortPingSwitch")]
    public required bool FirewallWanPortPingSwitch { get; init; }
}