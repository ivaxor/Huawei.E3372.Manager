using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Sms;

[XmlRoot("response")]
public record SmsListResponse : IModemPostResponse
{
    [XmlElement("Count")]
    public required int Count { get; init; }

    [XmlElement("Messages")]
    public required SmsListMessages Messages { get; init; }
}

public record SmsListMessages
{
    [XmlElement("Message")]
    public required SmsListMessage[] Message { get; init; }
}

public record SmsListMessage
{
    [XmlElement("Smstat")]
    public required SmsListMessageStatus Status { get; init; }

    [XmlElement("Index")]
    public required int Index { get; init; }

    [XmlElement("Phone")]
    public required string Phone { get; init; }

    [XmlElement("Content")]
    public required string Content { get; init; }

    [XmlElement("Date")]
    public required DateTime Date { get; init; }

    [XmlElement("Sca")]
    public required string Sca { get; init; }

    [XmlElement("SaveType")]
    public required int SaveType { get; init; }

    [XmlElement("Priority")]
    public required int Priority { get; init; }

    [XmlElement("SmsType")]
    public required int SmsType { get; init; }
}

public enum SmsListMessageStatus
{
    Unread = 0,
    Read = 1,
}