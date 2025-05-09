using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Config.Network;

[XmlRoot("config")]
public record NetModeResponse : IModemGetResponse
{
    [XmlElement("net_works")]
    public NetModeNetWorks NetWorks { get; init; }

    [XmlElement("net_modes")]
    public NetModeNetModes NetModes { get; init; }
}

public record NetModeNetWorks
{
    [XmlElement("net_work1")]
    public NetWorkModeItem NetWork1 { get; init; }

    [XmlElement("net_work2")]
    public NetWorkModeItem NetWork2 { get; init; }

    [XmlElement("net_work3")]
    public NetWorkModeItem NetWork3 { get; init; }

    [XmlElement("net_work4")]
    public NetWorkModeItem NetWork4 { get; init; }

    [XmlElement("net_work5")]
    public NetWorkModeItem NetWork5 { get; init; }
}

public record NetModeNetModes
{
    [XmlElement("net_mode1")]
    public NetWorkModeItem NetMode1 { get; init; }

    [XmlElement("net_mode2")]
    public NetWorkModeItem NetMode2 { get; init; }

    [XmlElement("net_mode3")]
    public NetWorkModeItem NetMode3 { get; init; }

    [XmlElement("net_mode4")]
    public NetWorkModeItem NetMode4 { get; init; }

    [XmlElement("net_mode5")]
    public NetWorkModeItem NetMode5 { get; init; }

    [XmlElement("net_mode6")]
    public NetWorkModeItem NetMode6 { get; init; }

    [XmlElement("net_mode7")]
    public NetWorkModeItem NetMode7 { get; init; }
}

public record NetWorkModeItem
{
    [XmlElement("index")]
    public int Index { get; init; }

    [XmlElement("networktype")]
    public string Networktype { get; init; }
}