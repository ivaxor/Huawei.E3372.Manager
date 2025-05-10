using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.WebServer;

[XmlRoot("response")]
public record WhiteListSwitchResponse : IModemGetResponse
{
    [XmlElement("whitelist_enable")]
    public bool WhiteListEnable { get; init; }
}