using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Dhcp;

[XmlRoot("response")]
public record DhcpSettingsResponse : IModemGetResponse
{
    [XmlElement("DhcpIPAddress")]
    public string IPAddress { get; init; }

    [XmlElement("DhcpLanNetmask")]
    public string LanNetmask { get; init; }

    [XmlElement("DhcpStatus")]
    public int Status { get; init; }

    [XmlElement("DhcpStartIPAddress")]
    public string StartIPAddress { get; init; }

    [XmlElement("DhcpEndIPAddress")]
    public string EndIPAddress { get; init; }

    [XmlElement("DhcpLeaseTime")]
    public int LeaseTime { get; init; }

    [XmlElement("DnsStatus")]
    public int DnsStatus { get; init; }

    [XmlElement("PrimaryDns")]
    public string PrimaryDns { get; init; }

    [XmlElement("SecondaryDns")]
    public string SecondaryDns { get; init; }
}