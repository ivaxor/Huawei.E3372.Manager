using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Sms;

[XmlRoot("response")]
public record SmsCountResponse : IModemGetResponse
{
    [XmlElement("LocalUnread")]
    public int LocalUnread { get; set; }

    [XmlElement("LocalInbox")]
    public int LocalInbox { get; set; }

    [XmlElement("LocalOutbox")]
    public int LocalOutbox { get; set; }

    [XmlElement("LocalDraft")]
    public int LocalDraft { get; set; }

    [XmlElement("LocalDeleted")]
    public int LocalDeleted { get; set; }

    [XmlElement("SimUnread")]
    public int SimUnread { get; set; }

    [XmlElement("SimInbox")]
    public int SimInbox { get; set; }

    [XmlElement("SimOutbox")]
    public int SimOutbox { get; set; }

    [XmlElement("SimDraft")]
    public int SimDraft { get; set; }

    [XmlElement("LocalMax")]
    public int LocalMax { get; set; }

    [XmlElement("SimMax")]
    public int SimMax { get; set; }

    [XmlElement("SimUsed")]
    public int SimUsed { get; set; }

    [XmlElement("NewMsg")]
    public int NewMsg { get; set; }
}