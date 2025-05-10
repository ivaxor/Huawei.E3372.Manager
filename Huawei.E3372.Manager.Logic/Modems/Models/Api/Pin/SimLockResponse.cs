using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Pin;

[XmlRoot("response")]
public record SimLockResponse : IModemGetResponse
{
    [XmlElement("SimLockEnable")]
    public bool SimLockEnable { get; init; }

    [XmlElement("SimLockRemainTimes")]
    public int SimLockRemainTimes { get; init; }

    [XmlElement("SimLockVersion")]
    public int SimLockVersion { get; init; }

    [XmlElement("pSimLockEnable")]
    public string PSimLockEnable { get; init; }

    [XmlElement("pSimLockRemainTimes")]
    public string PSimLockRemainTimes { get; init; }
}