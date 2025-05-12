using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Device;

[XmlRoot("response")]
public record SignalResponse : IModemGetResponse
{
    [XmlElement("pci")]
    public int Pci { get; set; }

    [XmlElement("sc")]
    public string Sc { get; set; }

    [XmlElement("cell_id")]
    public int CellId { get; set; }

    [XmlElement("rsrq")]
    public string Rsrq { get; set; }

    [XmlElement("rsrp")]
    public string Rsrp { get; set; }

    [XmlElement("rssi")]
    public string Rssi { get; set; }

    [XmlElement("sinr")]
    public string Sinr { get; set; }

    [XmlElement("rscp")]
    public string Rscp { get; set; }

    [XmlElement("ecio")]
    public string Ecio { get; set; }

    [XmlElement("psatt")]
    public int Psatt { get; set; }

    [XmlElement("mode")]
    public int Mode { get; set; }

    [XmlElement("lte_bandwidth")]
    public string LteBandwidth { get; set; }

    [XmlElement("lte_bandinfo")]
    public string LteBandInfo { get; set; }
}