using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Device;

[XmlRoot("response")]
public record BasicInformationResponse : IModemGetResponse
{
    [XmlElement("productfamily")]
    public required string ProductFamily { get; init; }

    [XmlElement("classify")]
    public required string Classify { get; init; }

    [XmlElement("multimode")]
    public required bool Multimode { get; init; }

    [XmlElement("restore_default_status")]
    public required bool RestoreDefaultStatus { get; init; }

    [XmlElement("autoupdate_guide_status")]
    public required bool AutoupdateGuideStatus { get; init; }

    [XmlElement("sim_save_pin_enable")]
    public required bool SimSavePinEnable { get; init; }

    [XmlElement("devicename")]
    public required string DeviceName { get; init; }

    [XmlElement("SoftwareVersion")]
    public required string SoftwareVersion { get; init; }

    [XmlElement("WebUIVersion")]
    public required string WebUIVersion { get; init; }
}