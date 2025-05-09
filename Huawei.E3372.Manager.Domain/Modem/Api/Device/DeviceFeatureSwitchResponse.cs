using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Device;

[XmlRoot("response")]
public record DeviceFeatureSwitchResponse : IModemGetResponse
{
    [XmlElement("coulometer_enabled")]
    public required bool CouloMeterEnabled { get; init; }

    [XmlElement("copyright_enabled")]
    public required bool CopyrightEnabled { get; init; }
}