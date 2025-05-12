using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Sms;

[XmlRoot("response")]
public record SmsListResponse : IModemPostResponse
{
    [XmlElement("Count")]
    public int Count { get; set; }

    [XmlElement("Messages")]
    public SmsListMessages Messages { get; set; }
}

public record SmsListMessages
{
    [XmlElement("Message")]
    public SmsListMessage[] Messages { get; set; }
}

public record SmsListMessage
{
    [XmlElement("Smstat")]
    public int Status { get; set; }

    [XmlElement("Index")]
    public int Index { get; set; }

    [XmlElement("Phone")]
    public string Phones { get; set; }

    [XmlElement("Content")]
    public string Content { get; set; }

    [XmlElement("Date")]
    public string Date { get; set; }

    [XmlElement("Sca")]
    public string Sca { get; set; }

    [XmlElement("SaveType")]
    public int SaveType { get; set; }

    [XmlElement("Priority")]
    public int Priority { get; set; }

    [XmlElement("SmsType")]
    public int Type { get; set; }
}