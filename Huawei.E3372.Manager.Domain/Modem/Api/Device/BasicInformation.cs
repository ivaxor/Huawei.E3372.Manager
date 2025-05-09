using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Device;

[XmlRoot("response")]
public record BasicInformation : IModemGetResponse
{
    [XmlElement("productfamily")]
    public string? ProductFamily { get; init; }

    [XmlElement("classify")]
    public string? Classify { get; init; }

    [XmlElement("multimode")]
    public int Multimode { get; init; }

    [XmlElement("restore_default_status")]
    public int RestoreDefaultStatus { get; init; }

    [XmlElement("autoupdate_guide_status")]
    public int AutoupdateGuideStatus { get; init; }

    [XmlElement("sim_save_pin_enable")]
    public int SimSavePinEnable { get; init; }

    [XmlElement("devicename")]
    public string? DeviceName { get; init; }

    [XmlElement("SoftwareVersion")]
    public string? SoftwareVersion { get; init; }

    [XmlElement("WebUIVersion")]
    public string? WebUIVersion { get; init; }
}