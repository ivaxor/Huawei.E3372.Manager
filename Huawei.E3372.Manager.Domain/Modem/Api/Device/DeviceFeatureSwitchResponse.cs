using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Device;

[XmlRoot("response")]
public record DeviceFeatureSwitchResponse : IModemGetResponse
{
    [XmlElement("coulometer_enabled")]
    public required int CouloMeterEnabled { get; init; }

    [XmlElement("copyright_enabled")]
    public required int CopyrightEnabled { get; init; }
}