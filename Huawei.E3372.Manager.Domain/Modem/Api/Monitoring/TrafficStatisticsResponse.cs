using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Monitoring;

[XmlRoot("response")]
public record TrafficStatisticsResponse : IModemGetResponse
{
    [XmlElement("CurrentConnectTime")]
    public required bool CurrentConnectTime { get; init; }

    [XmlElement("CurrentUpload")]
    public required bool CurrentUpload { get; init; }

    [XmlElement("CurrentDownload")]
    public required bool CurrentDownload { get; init; }

    [XmlElement("CurrentDownloadRate")]
    public required bool CurrentDownloadRate { get; init; }

    [XmlElement("CurrentUploadRate")]
    public required bool CurrentUploadRate { get; init; }

    [XmlElement("TotalUpload")]
    public required long TotalUpload { get; init; }

    [XmlElement("TotalDownload")]
    public required long TotalDownload { get; init; }

    [XmlElement("TotalConnectTime")]
    public required long TotalConnectTime { get; init; }

    [XmlElement("showtraffic")]
    public required bool ShowTraffic { get; init; }
}