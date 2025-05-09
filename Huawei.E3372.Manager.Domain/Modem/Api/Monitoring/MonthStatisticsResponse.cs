using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Monitoring;

[XmlRoot("response")]
public record MonthStatisticsResponse : IModemGetResponse
{
    [XmlElement("CurrentMonthDownload")]
    public required long CurrentMonthDownload { get; init; }

    [XmlElement("CurrentMonthUpload")]
    public required long CurrentMonthUpload { get; init; }

    [XmlElement("MonthDuration")]
    public required long MonthDuration { get; init; }

    [XmlElement("MonthLastClearTime")]
    public required string MonthLastClearTime { get; init; }
}