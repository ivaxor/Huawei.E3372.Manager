using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Device;

[XmlRoot("response")]
public record BasicInformationResponse : IModemGetResponse
{
    [XmlElement("productfamily")]
    public string ProductFamily { get; set; }

    [XmlElement("classify")]
    public string Classify { get; set; }

    [XmlElement("multimode")]
    public bool Multimode { get; set; }

    [XmlElement("restore_default_status")]
    public bool RestoreDefaultStatus { get; set; }

    [XmlElement("autoupdate_guide_status")]
    public bool AutoupdateGuideStatus { get; set; }

    [XmlElement("sim_save_pin_enable")]
    public bool SimSavePinEnable { get; set; }

    [XmlElement("devicename")]
    public string DeviceName { get; set; }

    [XmlElement("SoftwareVersion")]
    public string SoftwareVersion { get; set; }

    [XmlElement("WebUIVersion")]
    public string WebUIVersion { get; set; }
}