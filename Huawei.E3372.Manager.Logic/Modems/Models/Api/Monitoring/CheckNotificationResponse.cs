using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Monitoring;

[XmlRoot("response")]
public record CheckNotificationResponse : IModemGetResponse
{
    [XmlElement("UnreadMessage")]
    public int UnreadMessage { get; set; }

    [XmlElement("SmsStorageFull")]
    public bool SmsStorageFull { get; set; }

    [XmlElement("OnlineUpdateStatus")]
    public int OnlineUpdateStatus { get; set; }
}