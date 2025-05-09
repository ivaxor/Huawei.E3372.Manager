using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Pin;

[XmlRoot("response")]
public record SimLockResponse : IModemGetResponse
{
    [XmlElement("SimLockEnable")]
    public required int SimLockEnable { get; init; }

    [XmlElement("SimLockRemainTimes")]
    public required int SimLockRemainTimes { get; init; }

    [XmlElement("SimLockVersion")]
    public required int SimLockVersion { get; init; }

    [XmlElement("pSimLockEnable")]
    public required string PSimLockEnable { get; init; }

    [XmlElement("pSimLockRemainTimes")]
    public required string PSimLockRemainTimes { get; init; }
}