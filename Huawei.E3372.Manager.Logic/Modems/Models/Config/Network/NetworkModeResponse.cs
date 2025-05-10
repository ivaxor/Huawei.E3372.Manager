using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Config.Network;

[XmlRoot("config")]
public record NetworkModeResponse : IModemGetResponse
{
    [XmlElement("NetworkModes")]
    public NetworkModes NetworkModes { get; init; }

    [XmlElement("networkband_enable")]
    public bool NetworkBandEnable { get; init; }

    [XmlElement("networksearch")]
    public bool NetworkSearch { get; init; }

    [XmlElement("networksearchwhenconnected")]
    public bool NetworkSearchWhenConnected { get; init; }
}

public record NetworkModes
{
    [XmlElement("Mode")]
    public int[] Modes { get; init; }
}