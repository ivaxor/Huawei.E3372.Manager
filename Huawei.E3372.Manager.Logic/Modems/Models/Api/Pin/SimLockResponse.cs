using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Pin;

[XmlRoot("response")]
public record SimLockResponse : IModemGetResponse
{
    [XmlElement("SimLockEnable")]
    public bool SimLockEnable { get; set; }

    [XmlElement("SimLockRemainTimes")]
    public int SimLockRemainTimes { get; set; }

    [XmlElement("SimLockVersion")]
    public int SimLockVersion { get; set; }

    [XmlElement("pSimLockEnable")]
    public string PSimLockEnable { get; set; }

    [XmlElement("pSimLockRemainTimes")]
    public string PSimLockRemainTimes { get; set; }
}