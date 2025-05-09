using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Config.DeviceInformation;

[XmlRoot("config")]
public record AddParamResponse : IModemGetResponse
{
    [XmlElement("lac")]
    public required string Lac { get; init; }

    [XmlElement("cell_id")]
    public required string CellId { get; init; }

    [XmlElement("band")]
    public required string Band { get; init; }

    [XmlElement("earfcn1")]
    public required string Earfcn1 { get; init; }

    [XmlElement("freq1")]
    public required string Freq1 { get; init; }

    [XmlElement("bandwidth1")]
    public required string Bandwidth1 { get; init; }

    [XmlElement("earfcn2")]
    public required string Earfcn2 { get; init; }

    [XmlElement("freq2")]
    public required string Freq2 { get; init; }

    [XmlElement("bandwidth2")]
    public required string Bandwidth2 { get; init; }

    [XmlElement("rssi")]
    public required string Rssi { get; init; }

    [XmlElement("cnt")]
    public required int Cnt { get; init; }
}