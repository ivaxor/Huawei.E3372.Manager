using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Net;

[XmlRoot("response")]
public record NetModeListResponse : IModemGetResponse
{
    [XmlElement("AccessList")]
    public NetModeListAccessList AccessList { get; set; }

    [XmlElement("BandList")]
    public NetModeListBandList BandList { get; set; }

    [XmlElement("LTEBandList")]
    public NetModeListLTEBandList LTEBandList { get; set; }
}

public record NetModeListAccessList
{
    [XmlElement("Access")]
    public string[] Accesses { get; set; }
}

public record NetModeListBandList
{
    [XmlElement("Band")]
    public NetModeListBandInfo[] Bands { get; set; }
}

public record NetModeListBandInfo
{
    [XmlElement("Name")]
    public string Name { get; set; }

    [XmlElement("Value")]
    public string Value { get; set; }
}

public record NetModeListLTEBandList
{
    [XmlElement("LTEBand")]
    public NetModeListBandInfo[] LTEBands { get; set; }
}