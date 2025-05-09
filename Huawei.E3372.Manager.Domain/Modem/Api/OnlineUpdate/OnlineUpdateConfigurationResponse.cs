using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.OnlineUpdate;

[XmlRoot("response")]
public record OnlineUpdateConfigurationResponse : IModemGetResponse
{
    [XmlElement("autoUpdateInterval")]
    public required int AutoUpdateInterval { get; init; }

    [XmlElement("auto_update_enable")]
    public required int AutoUpdateEnable { get; init; }

    [XmlElement("server_force_enable")]
    public required int ServerForceEnable { get; init; }
}