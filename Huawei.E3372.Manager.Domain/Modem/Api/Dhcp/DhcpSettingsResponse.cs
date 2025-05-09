using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Dhcp;

[XmlRoot("response")]
public record DhcpSettingsResponse : IModemGetResponse
{
    [XmlElement("DhcpIPAddress")]
    public required string IPAddress { get; init; }

    [XmlElement("DhcpLanNetmask")]
    public required string LanNetmask { get; init; }

    [XmlElement("DhcpStatus")]
    public required int Status { get; init; }

    [XmlElement("DhcpStartIPAddress")]
    public required string StartIPAddress { get; init; }

    [XmlElement("DhcpEndIPAddress")]
    public required string EndIPAddress { get; init; }

    [XmlElement("DhcpLeaseTime")]
    public required int LeaseTime { get; init; }

    [XmlElement("DnsStatus")]
    public required int DnsStatus { get; init; }

    [XmlElement("PrimaryDns")]
    public required string PrimaryDns { get; init; }

    [XmlElement("SecondaryDns")]
    public required string SecondaryDns { get; init; }
}