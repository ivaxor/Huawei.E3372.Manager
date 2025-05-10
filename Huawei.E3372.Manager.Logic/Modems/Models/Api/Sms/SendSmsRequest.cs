using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Sms;
 
[XmlRoot("request")]
public record SendSmsRequest : IModemPostRequest
{
    [XmlElement("Index")]
    public int Index { get; init; }

    [XmlElement("Phones")]
    public SendSmsPhones Phones { get; init; }

    [XmlElement("Sca")]
    public string Sca { get; init; }

    [XmlElement("Content")]
    public string Content { get; init; }

    [XmlElement("Length")]
    public int Length { get; init; }

    [XmlElement("Reserved")]
    public bool Reserved { get; init; }

    [XmlElement("Date")]
    public string Date { get; init; }
}

public record SendSmsPhones
{
    [XmlElement("Phone")]
    public string[] Phones { get; init; }
}