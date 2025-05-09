using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Sms;

[XmlRoot("response")]
public record SmsFeatureSwitchResponse : IModemGetResponse
{
    [XmlElement("getcontactenable")]
    public required int Getcontactenable { get; init; }
}