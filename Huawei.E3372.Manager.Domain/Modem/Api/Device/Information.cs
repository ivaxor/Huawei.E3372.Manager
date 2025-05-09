using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Device;

[XmlRoot("response")]
public record Information : IModemGetResponse
{
    [XmlElement("DeviceName")]
    public string? DeviceName { get; init; }

    [XmlElement("SerialNumber")]
    public string? SerialNumber { get; init; }

    [XmlElement("Imei")]
    public string? Imei { get; init; }

    [XmlElement("Imsi")]
    public string? Imsi { get; init; }

    [XmlElement("Iccid")]
    public string? Iccid { get; init; }

    [XmlElement("Msisdn")]
    public string? Msisdn { get; init; }

    [XmlElement("HardwareVersion")]
    public string? HardwareVersion { get; init; }

    [XmlElement("SoftwareVersion")]
    public string? SoftwareVersion { get; init; }

    [XmlElement("WebUIVersion")]
    public string? WebUIVersion { get; init; }

    [XmlElement("MacAddress1")]
    public string? MacAddress1 { get; init; }

    [XmlElement("MacAddress2")]
    public string? MacAddress2 { get; init; }

    [XmlElement("ProductFamily")]
    public string? ProductFamily { get; init; }

    [XmlElement("Classify")]
    public string? Classify { get; init; }

    [XmlElement("supportmode")]
    public string? SupportMode { get; init; }

    [XmlElement("workmode")]
    public string? WorkMode { get; init; }

    [XmlElement("WanIPAddress")]
    public string? WanIPAddress { get; init; }

    [XmlElement("WanIPv6Address")]
    public string? WanIPv6Address { get; init; }
}