using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Monitoring;

[XmlRoot("response")]
public record TrafficStatistics : IModemGetResponse
{
    [XmlElement("CurrentConnectTime")]
    public int CurrentConnectTime { get; init; }

    [XmlElement("CurrentUpload")]
    public int CurrentUpload { get; init; }

    [XmlElement("CurrentDownload")]
    public int CurrentDownload { get; init; }

    [XmlElement("CurrentDownloadRate")]
    public int CurrentDownloadRate { get; init; }

    [XmlElement("CurrentUploadRate")]
    public int CurrentUploadRate { get; init; }

    [XmlElement("TotalUpload")]
    public long TotalUpload { get; init; }

    [XmlElement("TotalDownload")]
    public long TotalDownload { get; init; }

    [XmlElement("TotalConnectTime")]
    public long TotalConnectTime { get; init; }

    [XmlElement("showtraffic")]
    public int ShowTraffic { get; init; }
}