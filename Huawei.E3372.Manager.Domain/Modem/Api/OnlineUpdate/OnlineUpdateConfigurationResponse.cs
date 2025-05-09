using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.OnlineUpdate;

[XmlRoot("response")]
public record OnlineUpdateConfigurationResponse : IModemGetResponse
{
    [XmlElement("autoUpdateInterval")]
    public int AutoUpdateInterval { get; init; }

    [XmlElement("auto_update_enable")]
    public int AutoUpdateEnable { get; init; }

    [XmlElement("server_force_enable")]
    public int ServerForceEnable { get; init; }
}