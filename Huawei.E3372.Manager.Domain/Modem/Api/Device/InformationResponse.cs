using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Device;

[XmlRoot("response")]
public record InformationResponse : IModemGetResponse
{
    [XmlElement("DeviceName")]
    public required string DeviceName { get; init; }

    [XmlElement("SerialNumber")]
    public required string SerialNumber { get; init; }

    [XmlElement("Imei")]
    public required string Imei { get; init; }

    [XmlElement("Imsi")]
    public required string Imsi { get; init; }

    [XmlElement("Iccid")]
    public required string Iccid { get; init; }

    [XmlElement("Msisdn")]
    public required string Msisdn { get; init; }

    [XmlElement("HardwareVersion")]
    public required string HardwareVersion { get; init; }

    [XmlElement("SoftwareVersion")]
    public required string SoftwareVersion { get; init; }

    [XmlElement("WebUIVersion")]
    public required string WebUIVersion { get; init; }

    [XmlElement("MacAddress1")]
    public required string MacAddress1 { get; init; }

    [XmlElement("MacAddress2")]
    public required string MacAddress2 { get; init; }

    [XmlElement("ProductFamily")]
    public required string ProductFamily { get; init; }

    [XmlElement("Classify")]
    public required string Classify { get; init; }

    [XmlElement("supportmode")]
    public required string SupportMode { get; init; }

    [XmlElement("workmode")]
    public required string WorkMode { get; init; }

    [XmlElement("WanIPAddress")]
    public required string WanIPAddress { get; init; }

    [XmlElement("WanIPv6Address")]
    public required string WanIPv6Address { get; init; }
}