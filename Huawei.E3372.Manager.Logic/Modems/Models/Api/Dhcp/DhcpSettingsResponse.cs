using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Dhcp;

[XmlRoot("response")]
public record DhcpSettingsResponse : IModemGetResponse
{
    [XmlElement("DhcpIPAddress")]
    public string IPAddress { get; set; }

    [XmlElement("DhcpLanNetmask")]
    public string LanNetmask { get; set; }

    [XmlElement("DhcpStatus")]
    public int Status { get; set; }

    [XmlElement("DhcpStartIPAddress")]
    public string StartIPAddress { get; set; }

    [XmlElement("DhcpEndIPAddress")]
    public string EndIPAddress { get; set; }

    [XmlElement("DhcpLeaseTime")]
    public int LeaseTime { get; set; }

    [XmlElement("DnsStatus")]
    public int DnsStatus { get; set; }

    [XmlElement("PrimaryDns")]
    public string PrimaryDns { get; set; }

    [XmlElement("SecondaryDns")]
    public string SecondaryDns { get; set; }
}