using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Sms;

[XmlRoot("response")]
public record SmsFeatureSwitchResponse : IModemGetResponse
{
    [XmlElement("getcontactenable")]
    public bool GetContactEnable { get; set; }
}