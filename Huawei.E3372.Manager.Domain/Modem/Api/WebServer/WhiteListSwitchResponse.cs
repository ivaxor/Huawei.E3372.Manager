using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.WebServer;

[XmlRoot("response")]
public record WhiteListSwitchResponse : IModemGetResponse
{
    [XmlElement("whitelist_enable")]
    public required bool WhiteListEnable { get; init; }
}