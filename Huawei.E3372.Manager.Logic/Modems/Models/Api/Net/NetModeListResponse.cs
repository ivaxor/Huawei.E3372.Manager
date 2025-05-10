using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Net;

[XmlRoot("response")]
public record NetModeListResponse : IModemGetResponse
{
    [XmlElement("AccessList")]
    public NetModeListAccessList AccessList { get; init; }

    [XmlElement("BandList")]
    public NetModeListBandList BandList { get; init; }

    [XmlElement("LTEBandList")]
    public NetModeListLTEBandList LTEBandList { get; init; }
}

public record NetModeListAccessList
{
    [XmlElement("Access")]
    public string[] Accesses { get; init; }
}

public record NetModeListBandList
{
    [XmlElement("Band")]
    public NetModeListBandInfo[] Bands { get; init; }
}

public record NetModeListBandInfo
{
    [XmlElement("Name")]
    public string Name { get; init; }

    [XmlElement("Value")]
    public string Value { get; init; }
}

public record NetModeListLTEBandList
{
    [XmlElement("LTEBand")]
    public NetModeListBandInfo[] LTEBands { get; init; }
}