using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Monitoring;

[XmlRoot("response")]
public record TrafficStatisticsResponse : IModemGetResponse
{
    [XmlElement("CurrentConnectTime")]
    public bool CurrentConnectTime { get; init; }

    [XmlElement("CurrentUpload")]
    public bool CurrentUpload { get; init; }

    [XmlElement("CurrentDownload")]
    public bool CurrentDownload { get; init; }

    [XmlElement("CurrentDownloadRate")]
    public bool CurrentDownloadRate { get; init; }

    [XmlElement("CurrentUploadRate")]
    public bool CurrentUploadRate { get; init; }

    [XmlElement("TotalUpload")]
    public long TotalUpload { get; init; }

    [XmlElement("TotalDownload")]
    public long TotalDownload { get; init; }

    [XmlElement("TotalConnectTime")]
    public long TotalConnectTime { get; init; }

    [XmlElement("showtraffic")]
    public bool ShowTraffic { get; init; }
}