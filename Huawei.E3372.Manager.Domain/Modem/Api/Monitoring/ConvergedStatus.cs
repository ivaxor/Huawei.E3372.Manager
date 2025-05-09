using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Monitoring;

[XmlRoot("response")]
public record ConvergedStatus : IModemGetResponse
{
    [XmlElement("SimState")]
    public int SimState { get; init; }

    [XmlElement("SimLockEnable")]
    public int SimLockEnable { get; init; }

    [XmlElement("CurrentLanguage")]
    public string? CurrentLanguage { get; init; }
}