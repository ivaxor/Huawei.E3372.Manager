using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Config.DeviceInformation;

[XmlRoot("config")]
public record AddParamResponse : IModemGetResponse
{
    [XmlElement("lac")]
    public string Lac { get; set; }

    [XmlElement("cell_id")]
    public string CellId { get; set; }

    [XmlElement("band")]
    public string Band { get; set; }

    [XmlElement("earfcn1")]
    public string Earfcn1 { get; set; }

    [XmlElement("freq1")]
    public string Freq1 { get; set; }

    [XmlElement("bandwidth1")]
    public string Bandwidth1 { get; set; }

    [XmlElement("earfcn2")]
    public string Earfcn2 { get; set; }

    [XmlElement("freq2")]
    public string Freq2 { get; set; }

    [XmlElement("bandwidth2")]
    public string Bandwidth2 { get; set; }

    [XmlElement("rssi")]
    public string Rssi { get; set; }

    [XmlElement("cnt")]
    public int Cnt { get; set; }
}