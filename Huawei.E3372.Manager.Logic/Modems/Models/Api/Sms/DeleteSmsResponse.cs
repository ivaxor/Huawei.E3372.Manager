using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Sms;

[XmlRoot("response")]
public record DeleteSmsResponse : IModemPostResponse
{
    [XmlText]
    public string? Value { get; set; }
}