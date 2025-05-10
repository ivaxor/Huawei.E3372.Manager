using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Device;

[XmlRoot("response")]
public record BasicInformationResponse : IModemGetResponse
{
    [XmlElement("productfamily")]
    public string ProductFamily { get; init; }

    [XmlElement("classify")]
    public string Classify { get; init; }

    [XmlElement("multimode")]
    public bool Multimode { get; init; }

    [XmlElement("restore_default_status")]
    public bool RestoreDefaultStatus { get; init; }

    [XmlElement("autoupdate_guide_status")]
    public bool AutoupdateGuideStatus { get; init; }

    [XmlElement("sim_save_pin_enable")]
    public bool SimSavePinEnable { get; init; }

    [XmlElement("devicename")]
    public string DeviceName { get; init; }

    [XmlElement("SoftwareVersion")]
    public string SoftwareVersion { get; init; }

    [XmlElement("WebUIVersion")]
    public string WebUIVersion { get; init; }
}