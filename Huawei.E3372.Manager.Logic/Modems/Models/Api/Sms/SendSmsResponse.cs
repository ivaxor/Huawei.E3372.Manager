using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Sms;

[XmlRoot("response")]
public record SendSmsResponse : IModemPostResponse
{
    [XmlText]
    public string? Value { get; init; }
}