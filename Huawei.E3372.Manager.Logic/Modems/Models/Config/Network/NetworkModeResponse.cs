using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Config.Network;

[XmlRoot("config")]
public record NetworkModeResponse : IModemGetResponse
{
    [XmlElement("NetworkModes")]
    public NetworkModes NetworkModes { get; set; }

    [XmlElement("networkband_enable")]
    public bool NetworkBandEnable { get; set; }

    [XmlElement("networksearch")]
    public bool NetworkSearch { get; set; }

    [XmlElement("networksearchwhenconnected")]
    public bool NetworkSearchWhenConnected { get; set; }
}

public record NetworkModes
{
    [XmlElement("Mode")]
    public int[] Modes { get; set; }
}