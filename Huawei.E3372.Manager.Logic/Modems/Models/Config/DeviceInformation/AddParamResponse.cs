using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Config.DeviceInformation;

[XmlRoot("config")]
public record AddParamResponse : IModemGetResponse
{
    [XmlElement("lac")]
    public string Lac { get; init; }

    [XmlElement("cell_id")]
    public string CellId { get; init; }

    [XmlElement("band")]
    public string Band { get; init; }

    [XmlElement("earfcn1")]
    public string Earfcn1 { get; init; }

    [XmlElement("freq1")]
    public string Freq1 { get; init; }

    [XmlElement("bandwidth1")]
    public string Bandwidth1 { get; init; }

    [XmlElement("earfcn2")]
    public string Earfcn2 { get; init; }

    [XmlElement("freq2")]
    public string Freq2 { get; init; }

    [XmlElement("bandwidth2")]
    public string Bandwidth2 { get; init; }

    [XmlElement("rssi")]
    public string Rssi { get; init; }

    [XmlElement("cnt")]
    public int Cnt { get; init; }
}