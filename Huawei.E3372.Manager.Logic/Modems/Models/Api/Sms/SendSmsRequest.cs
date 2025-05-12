using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Sms;
 
[XmlRoot("request")]
public record SendSmsRequest : IModemPostRequest
{
    [XmlElement("Index")]
    public int Index { get; set; }

    [XmlElement("Phones")]
    public SendSmsPhones Phones { get; set; }

    [XmlElement("Sca")]
    public string Sca { get; set; }

    [XmlElement("Content")]
    public string Content { get; set; }

    [XmlElement("Length")]
    public int Length { get; set; }

    [XmlElement("Reserved")]
    public bool Reserved { get; set; }

    [XmlElement("Date")]
    public string Date { get; set; }
}

public record SendSmsPhones
{
    [XmlElement("Phone")]
    public string[] Phones { get; set; }
}