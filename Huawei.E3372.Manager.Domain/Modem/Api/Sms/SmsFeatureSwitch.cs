using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Sms;

[XmlRoot("response")]
public record SmsFeatureSwitch : IModemGetResponse
{
    [XmlElement("getcontactenable")]
    public int Getcontactenable { get; init; }
}