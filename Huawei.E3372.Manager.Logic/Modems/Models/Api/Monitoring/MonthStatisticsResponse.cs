using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Monitoring;

[XmlRoot("response")]
public record MonthStatisticsResponse : IModemGetResponse
{
    [XmlElement("CurrentMonthDownload")]
    public long CurrentMonthDownload { get; set; }

    [XmlElement("CurrentMonthUpload")]
    public long CurrentMonthUpload { get; set; }

    [XmlElement("MonthDuration")]
    public long MonthDuration { get; set; }

    [XmlElement("MonthLastClearTime")]
    public string MonthLastClearTime { get; set; }
}