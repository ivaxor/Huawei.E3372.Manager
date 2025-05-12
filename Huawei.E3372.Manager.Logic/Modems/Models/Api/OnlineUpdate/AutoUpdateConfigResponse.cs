using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.OnlineUpdate;

[XmlRoot("response")]
public record AutoUpdateConfigResponse : IModemGetResponse
{
    [XmlElement("auto_update")]
    public bool AutoUpdate { get; set; }

    [XmlElement("ui_download")]
    public bool UiDownload { get; set; }
}