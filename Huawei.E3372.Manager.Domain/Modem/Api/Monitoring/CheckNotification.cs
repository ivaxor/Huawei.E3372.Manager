using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Monitoring;

[XmlRoot("response")]
public record CheckNotification : IModemGetResponse
{
    [XmlElement("UnreadMessage")]
    public int UnreadMessage { get; init; }

    [XmlElement("SmsStorageFull")]
    public int SmsStorageFull { get; init; }

    [XmlElement("OnlineUpdateStatus")]
    public int OnlineUpdateStatus { get; init; }
}