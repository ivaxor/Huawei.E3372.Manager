using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Device;

[XmlRoot("response")]
public record DeviceFeatureSwitch : IModemGetResponse
{
    [XmlElement("coulometer_enabled")]
    public int CouloMeterEnabled { get; init; }

    [XmlElement("copyright_enabled")]
    public int CopyrightEnabled { get; init; }
}