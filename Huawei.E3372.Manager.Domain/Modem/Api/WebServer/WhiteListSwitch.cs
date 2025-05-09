using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.WebServer;

[XmlRoot("response")]
public record WhiteListSwitch : IModemGetResponse
{
    [XmlElement("whitelist_enable")]
    public int WhiteListEnable { get; init; }
}