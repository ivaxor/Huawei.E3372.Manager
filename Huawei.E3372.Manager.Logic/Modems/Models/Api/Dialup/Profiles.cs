using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Dialup;

[XmlRoot("response")]
public record ProfilesResponse : IModemGetResponse
{
    [XmlElement("CurrentProfile")]
    public int CurrentProfile { get; init; }

    [XmlElement("Profiles")]
    public Profiles Profiles { get; init; }
}

public record Profiles
{
    [XmlElement("Profile")]
    public Profile[] Profile { get; init; }
}

public record Profile
{
    [XmlElement("Index")]
    public int Index { get; init; }

    [XmlElement("IsValid")]
    public int IsValid { get; init; }

    [XmlElement("Name")]
    public string Name { get; init; }

    [XmlElement("ApnIsStatic")]
    public int ApnIsStatic { get; init; }

    [XmlElement("ApnName")]
    public string ApnName { get; init; }

    [XmlElement("DialupNum")]
    public string DialupNum { get; init; }

    [XmlElement("Username")]
    public string Username { get; init; }

    [XmlElement("Password")]
    public string Password { get; init; }

    [XmlElement("AuthMode")]
    public int AuthMode { get; init; }

    [XmlElement("IpIsStatic")]
    public int IpIsStatic { get; init; }

    [XmlElement("IpAddress")]
    public string IpAddress { get; init; }

    [XmlElement("Ipv6Address")]
    public string Ipv6Address { get; init; }

    [XmlElement("DnsIsStatic")]
    public int DnsIsStatic { get; init; }

    [XmlElement("PrimaryDns")]
    public string PrimaryDns { get; init; }

    [XmlElement("SecondaryDns")]
    public string SecondaryDns { get; init; }

    [XmlElement("PrimaryIpv6Dns")]
    public string PrimaryIpv6Dns { get; init; }

    [XmlElement("SecondaryIpv6Dns")]
    public string SecondaryIpv6Dns { get; init; }

    [XmlElement("ReadOnly")]
    public int ReadOnly { get; init; }

    [XmlElement("iptype")]
    public int IpType { get; init; }
}