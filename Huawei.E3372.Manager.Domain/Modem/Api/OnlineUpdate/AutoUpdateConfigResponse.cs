using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.OnlineUpdate;

[XmlRoot("response")]
public record AutoUpdateConfigResponse : IModemGetResponse
{
    [XmlElement("auto_update")]
    public required bool AutoUpdate { get; init; }

    [XmlElement("ui_download")]
    public required bool UiDownload { get; init; }
}