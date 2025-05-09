using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Monitoring;

[XmlRoot("response")]
public record ConvergedStatusResponse : IModemGetResponse
{
    [XmlElement("SimState")]
    public required int SimState { get; init; }

    [XmlElement("SimLockEnable")]
    public required int SimLockEnable { get; init; }

    [XmlElement("CurrentLanguage")]
    public required string CurrentLanguage { get; init; }
}