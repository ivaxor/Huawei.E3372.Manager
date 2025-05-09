using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.OnlineUpdate;

[XmlRoot("response")]
public record AutoUpdateConfigResponse : IModemGetResponse
{
    [XmlElement("auto_update")]
    public required int AutoUpdate { get; init; }

    [XmlElement("ui_download")]
    public required int UiDownload { get; init; }
}