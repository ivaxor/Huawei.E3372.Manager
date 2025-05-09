using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Config.Network;

[XmlRoot("config")]
public record NetworkModeResponse : IModemGetResponse
{
    [XmlElement("NetworkModes")]
    public required NetworkModes NetworkModes { get; init; }

    [XmlElement("networkband_enable")]
    public required bool NetworkBandEnable { get; init; }

    [XmlElement("networksearch")]
    public required bool NetworkSearch { get; init; }

    [XmlElement("networksearchwhenconnected")]
    public required bool NetworkSearchWhenConnected { get; init; }
}

public record NetworkModes
{
    [XmlElement("Mode")]
    public int[] Modes { get; init; }
}