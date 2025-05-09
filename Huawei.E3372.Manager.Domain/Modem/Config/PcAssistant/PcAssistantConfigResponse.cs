using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Config.PcAssistant;

[XmlRoot("config")]
public record PcAssistantConfigResponse : IModemGetResponse
{
    [XmlElement("enable")]
    public required bool Enable { get; init; }

    [XmlElement("winpath")]
    public required string WinPath { get; init; }

    [XmlElement("macpath")]
    public required string MacPath { get; init; }

    [XmlElement("upgradepath")]
    public required string UpgradePath { get; init; }
}