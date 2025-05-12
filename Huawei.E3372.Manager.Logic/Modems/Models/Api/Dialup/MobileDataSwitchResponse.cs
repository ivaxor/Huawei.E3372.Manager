using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Dialup;

[XmlRoot("response")]
public record MobileDataSwitchResponse : IModemGetResponse
{
    [XmlElement("dataswitch")]
    public bool DataSwitch { get; set; }
}