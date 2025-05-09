using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Pin;

[XmlRoot("response")]
public record SimLock : IModemGetResponse
{
    [XmlElement("SimLockEnable")]
    public int SimLockEnable { get; init; }

    [XmlElement("SimLockRemainTimes")]
    public int SimLockRemainTimes { get; init; }

    [XmlElement("SimLockVersion")]
    public int SimLockVersion { get; init; }

    [XmlElement("pSimLockEnable")]
    public string? PSimLockEnable { get; init; }

    [XmlElement("pSimLockRemainTimes")]
    public string? PSimLockRemainTimes { get; init; }
}