using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Sms;

[XmlRoot("response")]
public record SmsCountResponse : IModemGetResponse
{
    [XmlElement("LocalUnread")]
    public required int LocalUnread { get; init; }

    [XmlElement("LocalInbox")]
    public required int LocalInbox { get; init; }

    [XmlElement("LocalOutbox")]
    public required int LocalOutbox { get; init; }

    [XmlElement("LocalDraft")]
    public required int LocalDraft { get; init; }

    [XmlElement("LocalDeleted")]
    public required int LocalDeleted { get; init; }

    [XmlElement("SimUnread")]
    public required int SimUnread { get; init; }

    [XmlElement("SimInbox")]
    public required int SimInbox { get; init; }

    [XmlElement("SimOutbox")]
    public required int SimOutbox { get; init; }

    [XmlElement("SimDraft")]
    public required int SimDraft { get; init; }

    [XmlElement("LocalMax")]
    public required int LocalMax { get; init; }

    [XmlElement("SimMax")]
    public required int SimMax { get; init; }

    [XmlElement("SimUsed")]
    public required int SimUsed { get; init; }

    [XmlElement("NewMsg")]
    public required int NewMsg { get; init; }
}