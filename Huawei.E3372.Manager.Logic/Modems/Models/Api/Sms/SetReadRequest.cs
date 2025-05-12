using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Sms;

[XmlRoot("request")]
public record SetReadRequest : IModemPostRequest
{
    [XmlElement("Index")]
    public int Index { get; set; }
}