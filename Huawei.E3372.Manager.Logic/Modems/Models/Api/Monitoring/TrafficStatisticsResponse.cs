using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Monitoring;

[XmlRoot("response")]
public record TrafficStatisticsResponse : IModemGetResponse
{
    [XmlElement("CurrentConnectTime")]
    public bool CurrentConnectTime { get; set; }

    [XmlElement("CurrentUpload")]
    public bool CurrentUpload { get; set; }

    [XmlElement("CurrentDownload")]
    public bool CurrentDownload { get; set; }

    [XmlElement("CurrentDownloadRate")]
    public bool CurrentDownloadRate { get; set; }

    [XmlElement("CurrentUploadRate")]
    public bool CurrentUploadRate { get; set; }

    [XmlElement("TotalUpload")]
    public long TotalUpload { get; set; }

    [XmlElement("TotalDownload")]
    public long TotalDownload { get; set; }

    [XmlElement("TotalConnectTime")]
    public long TotalConnectTime { get; set; }

    [XmlElement("showtraffic")]
    public bool ShowTraffic { get; set; }
}