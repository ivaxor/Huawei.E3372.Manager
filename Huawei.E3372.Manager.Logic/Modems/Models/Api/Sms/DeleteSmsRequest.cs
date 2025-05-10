using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Sms;

[XmlRoot("request")]
public record DeleteSmsRequest : IModemPostRequest
{
    [XmlElement("Index")]
    public int Index { get; init; }
}