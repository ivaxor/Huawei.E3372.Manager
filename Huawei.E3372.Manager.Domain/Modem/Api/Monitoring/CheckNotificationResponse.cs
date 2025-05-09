using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Monitoring;

[XmlRoot("response")]
public record CheckNotificationResponse : IModemGetResponse
{
    [XmlElement("UnreadMessage")]
    public required int UnreadMessage { get; init; }

    [XmlElement("SmsStorageFull")]
    public required int SmsStorageFull { get; init; }

    [XmlElement("OnlineUpdateStatus")]
    public required int OnlineUpdateStatus { get; init; }
}