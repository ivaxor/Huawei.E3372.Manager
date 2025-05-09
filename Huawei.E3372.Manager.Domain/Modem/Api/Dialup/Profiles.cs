using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Dialup;

[XmlRoot("response")]
public record ProfilesResponse : IModemGetResponse
{
    [XmlElement("CurrentProfile")]
    public required int CurrentProfile { get; init; }

    [XmlElement("Profiles")]
    public required Profiles Profiles { get; init; }
}

public record Profiles
{
    [XmlElement("Profile")]
    public required Profile[] Profile { get; init; }
}

public record Profile
{
    [XmlElement("Index")]
    public required int Index { get; init; }

    [XmlElement("IsValid")]
    public required int IsValid { get; init; }

    [XmlElement("Name")]
    public required string Name { get; init; }

    [XmlElement("ApnIsStatic")]
    public required int ApnIsStatic { get; init; }

    [XmlElement("ApnName")]
    public required string ApnName { get; init; }

    [XmlElement("DialupNum")]
    public required string DialupNum { get; init; }

    [XmlElement("Username")]
    public required string Username { get; init; }

    [XmlElement("Password")]
    public required string Password { get; init; }

    [XmlElement("AuthMode")]
    public required int AuthMode { get; init; }

    [XmlElement("IpIsStatic")]
    public required int IpIsStatic { get; init; }

    [XmlElement("IpAddress")]
    public required string IpAddress { get; init; }

    [XmlElement("Ipv6Address")]
    public required string Ipv6Address { get; init; }

    [XmlElement("DnsIsStatic")]
    public required int DnsIsStatic { get; init; }

    [XmlElement("PrimaryDns")]
    public required string PrimaryDns { get; init; }

    [XmlElement("SecondaryDns")]
    public required string SecondaryDns { get; init; }

    [XmlElement("PrimaryIpv6Dns")]
    public required string PrimaryIpv6Dns { get; init; }

    [XmlElement("SecondaryIpv6Dns")]
    public required string SecondaryIpv6Dns { get; init; }

    [XmlElement("ReadOnly")]
    public required int ReadOnly { get; init; }

    [XmlElement("iptype")]
    public required int IpType { get; init; }
}