using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Device;

[XmlRoot("response")]
public record InformationResponse : IModemGetResponse
{
    [XmlElement("DeviceName")]
    public string DeviceName { get; set; }

    [XmlElement("SerialNumber")]
    public string SerialNumber { get; set; }

    [XmlElement("Imei")]
    public string Imei { get; set; }

    [XmlElement("Imsi")]
    public string Imsi { get; set; }

    [XmlElement("Iccid")]
    public string Iccid { get; set; }

    [XmlElement("Msisdn")]
    public string Msisdn { get; set; }

    [XmlElement("HardwareVersion")]
    public string HardwareVersion { get; set; }

    [XmlElement("SoftwareVersion")]
    public string SoftwareVersion { get; set; }

    [XmlElement("WebUIVersion")]
    public string WebUIVersion { get; set; }

    [XmlElement("MacAddress1")]
    public string MacAddress1 { get; set; }

    [XmlElement("MacAddress2")]
    public string MacAddress2 { get; set; }

    [XmlElement("ProductFamily")]
    public string ProductFamily { get; set; }

    [XmlElement("Classify")]
    public string Classify { get; set; }

    [XmlElement("supportmode")]
    public string SupportMode { get; set; }

    [XmlElement("workmode")]
    public string WorkMode { get; set; }

    [XmlElement("WanIPAddress")]
    public string WanIPAddress { get; set; }

    [XmlElement("WanIPv6Address")]
    public string WanIPv6Address { get; set; }
}