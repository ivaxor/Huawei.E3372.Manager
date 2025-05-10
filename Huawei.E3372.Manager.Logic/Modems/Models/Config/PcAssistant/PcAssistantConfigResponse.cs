using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Config.PcAssistant;

[XmlRoot("config")]
public record PcAssistantConfigResponse : IModemGetResponse
{
    [XmlElement("enable")]
    public bool Enable { get; init; }

    [XmlElement("winpath")]
    public string WinPath { get; init; }

    [XmlElement("macpath")]
    public string MacPath { get; init; }

    [XmlElement("upgradepath")]
    public string UpgradePath { get; init; }
}