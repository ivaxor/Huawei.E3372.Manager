using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Config.PcAssistant;

[XmlRoot("config")]
public record PcAssistantConfigResponse : IModemGetResponse
{
    [XmlElement("enable")]
    public int Enable { get; init; }

    [XmlElement("winpath")]
    public string? WinPath { get; init; }

    [XmlElement("macpath")]
    public string? MacPath { get; init; }

    [XmlElement("upgradepath")]
    public string? UpgradePath { get; init; }
}