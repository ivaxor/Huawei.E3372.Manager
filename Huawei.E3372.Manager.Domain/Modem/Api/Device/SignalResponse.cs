using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Device;

[XmlRoot("response")]
public record SignalResponse : IModemGetResponse
{
    [XmlElement("pci")]
    public required int Pci { get; init; }

    [XmlElement("sc")]
    public required string Sc { get; init; }

    [XmlElement("cell_id")]
    public long CellId { get; init; }

    [XmlElement("rsrq")]
    public required string Rsrq { get; init; }

    [XmlElement("rsrp")]
    public required string Rsrp { get; init; }

    [XmlElement("rssi")]
    public required string Rssi { get; init; }

    [XmlElement("sinr")]
    public required string Sinr { get; init; }

    [XmlElement("rscp")]
    public required string Rscp { get; init; }

    [XmlElement("ecio")]
    public required string Ecio { get; init; }

    [XmlElement("psatt")]
    public required int Psatt { get; init; }

    [XmlElement("mode")]
    public required int Mode { get; init; }

    [XmlElement("lte_bandwidth")]
    public required string LteBandwidth { get; init; }

    [XmlElement("lte_bandinfo")]
    public required string LteBandInfo { get; init; }
}