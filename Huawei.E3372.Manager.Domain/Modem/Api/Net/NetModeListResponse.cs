using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Net;

[XmlRoot("response")]
public record NetModeListResponse : IModemGetResponse
{
    [XmlElement("AccessList")]
    public required NetModeListAccessList AccessList { get; init; }

    [XmlElement("BandList")]
    public required NetModeListBandList BandList { get; init; }

    [XmlElement("LTEBandList")]
    public required NetModeListLTEBandList LTEBandList { get; init; }
}

public record NetModeListAccessList
{
    [XmlElement("Access")]
    public required string[] Accesses { get; init; }
}

public record NetModeListBandList
{
    [XmlElement("Band")]
    public required NetModeListBandInfo[] Bands { get; init; }
}

public record NetModeListBandInfo
{
    [XmlElement("Name")]
    public required string Name { get; init; }

    [XmlElement("Value")]
    public required string Value { get; init; }
}

public record NetModeListLTEBandList
{
    [XmlElement("LTEBand")]
    public required NetModeListBandInfo[] LTEBands { get; init; }
}