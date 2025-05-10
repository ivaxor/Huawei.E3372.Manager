using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Device;

[XmlRoot("response")]
public record DeviceFeatureSwitchResponse : IModemGetResponse
{
    [XmlElement("coulometer_enabled")]
    public bool CouloMeterEnabled { get; init; }

    [XmlElement("copyright_enabled")]
    public bool CopyrightEnabled { get; init; }
}