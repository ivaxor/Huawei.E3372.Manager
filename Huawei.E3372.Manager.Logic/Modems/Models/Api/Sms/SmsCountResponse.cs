using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Sms;

[XmlRoot("response")]
public record SmsCountResponse : IModemGetResponse
{
    [XmlElement("LocalUnread")]
    public int LocalUnread { get; init; }

    [XmlElement("LocalInbox")]
    public int LocalInbox { get; init; }

    [XmlElement("LocalOutbox")]
    public int LocalOutbox { get; init; }

    [XmlElement("LocalDraft")]
    public int LocalDraft { get; init; }

    [XmlElement("LocalDeleted")]
    public int LocalDeleted { get; init; }

    [XmlElement("SimUnread")]
    public int SimUnread { get; init; }

    [XmlElement("SimInbox")]
    public int SimInbox { get; init; }

    [XmlElement("SimOutbox")]
    public int SimOutbox { get; init; }

    [XmlElement("SimDraft")]
    public int SimDraft { get; init; }

    [XmlElement("LocalMax")]
    public int LocalMax { get; init; }

    [XmlElement("SimMax")]
    public int SimMax { get; init; }

    [XmlElement("SimUsed")]
    public int SimUsed { get; init; }

    [XmlElement("NewMsg")]
    public int NewMsg { get; init; }
}