using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Dialup;

[XmlRoot("response")]
public record MobileDataSwitchResponse : IModemGetResponse
{
    [XmlElement("dataswitch")]
    public required bool DataSwitch { get; init; }
}