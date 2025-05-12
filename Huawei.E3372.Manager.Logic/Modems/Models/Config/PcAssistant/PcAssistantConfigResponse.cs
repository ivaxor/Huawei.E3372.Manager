using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Config.PcAssistant;

[XmlRoot("config")]
public record PcAssistantConfigResponse : IModemGetResponse
{
    [XmlElement("enable")]
    public bool Enable { get; set; }

    [XmlElement("winpath")]
    public string WinPath { get; set; }

    [XmlElement("macpath")]
    public string MacPath { get; set; }

    [XmlElement("upgradepath")]
    public string UpgradePath { get; set; }
}