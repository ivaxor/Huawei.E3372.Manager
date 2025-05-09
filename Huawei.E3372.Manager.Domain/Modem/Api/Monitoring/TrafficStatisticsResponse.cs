using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Monitoring;

[XmlRoot("response")]
public record TrafficStatisticsResponse : IModemGetResponse
{
    [XmlElement("CurrentConnectTime")]
    public required int CurrentConnectTime { get; init; }

    [XmlElement("CurrentUpload")]
    public required int CurrentUpload { get; init; }

    [XmlElement("CurrentDownload")]
    public required int CurrentDownload { get; init; }

    [XmlElement("CurrentDownloadRate")]
    public required int CurrentDownloadRate { get; init; }

    [XmlElement("CurrentUploadRate")]
    public required int CurrentUploadRate { get; init; }

    [XmlElement("TotalUpload")]
    public long TotalUpload { get; init; }

    [XmlElement("TotalDownload")]
    public long TotalDownload { get; init; }

    [XmlElement("TotalConnectTime")]
    public long TotalConnectTime { get; init; }

    [XmlElement("showtraffic")]
    public required int ShowTraffic { get; init; }
}