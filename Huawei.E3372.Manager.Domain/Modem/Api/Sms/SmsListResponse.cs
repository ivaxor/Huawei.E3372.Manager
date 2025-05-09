using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Sms;

[XmlRoot("response")]
public record SmsListResponse : IModemPostResponse
{
    [XmlElement("Count")]
    public int Count { get; init; }

    [XmlElement("Messages")]
    public SmsListMessages Messages { get; init; }
}

public record SmsListMessages
{
    [XmlElement("Message")]
    public List<SmsListMessage> Message { get; init; }
}

public record SmsListMessage
{
    [XmlElement("Smstat")]
    public int Smstat { get; init; }

    [XmlElement("Index")]
    public int Index { get; init; }

    [XmlElement("Phone")]
    public string? Phone { get; init; }

    [XmlElement("Content")]
    public string? Content { get; init; }

    [XmlElement("Date")]
    public string? Date { get; init; }

    [XmlElement("Sca")]
    public string? Sca { get; init; }

    [XmlElement("SaveType")]
    public int SaveType { get; init; }

    [XmlElement("Priority")]
    public int Priority { get; init; }

    [XmlElement("SmsType")]
    public int SmsType { get; init; }
}