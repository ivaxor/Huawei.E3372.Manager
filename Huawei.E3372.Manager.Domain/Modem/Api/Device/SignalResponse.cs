using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Device;

[XmlRoot("response")]
public record SignalResponse : IModemGetResponse
{
    [XmlElement("pci")]
    public int Pci { get; init; }

    [XmlElement("sc")]
    public string? Sc { get; init; }

    [XmlElement("cell_id")]
    public long CellId { get; init; }

    [XmlElement("rsrq")]
    public string? Rsrq { get; init; }

    [XmlElement("rsrp")]
    public string? Rsrp { get; init; }

    [XmlElement("rssi")]
    public string? Rssi { get; init; }

    [XmlElement("sinr")]
    public string? Sinr { get; init; }

    [XmlElement("rscp")]
    public string? Rscp { get; init; }

    [XmlElement("ecio")]
    public string? Ecio { get; init; }

    [XmlElement("psatt")]
    public int Psatt { get; init; }

    [XmlElement("mode")]
    public int Mode { get; init; }

    [XmlElement("lte_bandwidth")]
    public string? LteBandwidth { get; init; }

    [XmlElement("lte_bandinfo")]
    public string? LteBandInfo { get; init; }
}