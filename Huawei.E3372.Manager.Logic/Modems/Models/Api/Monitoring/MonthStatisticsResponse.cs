using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Monitoring;

[XmlRoot("response")]
public record MonthStatisticsResponse : IModemGetResponse
{
    [XmlElement("CurrentMonthDownload")]
    public long CurrentMonthDownload { get; init; }

    [XmlElement("CurrentMonthUpload")]
    public long CurrentMonthUpload { get; init; }

    [XmlElement("MonthDuration")]
    public long MonthDuration { get; init; }

    [XmlElement("MonthLastClearTime")]
    public string MonthLastClearTime { get; init; }
}