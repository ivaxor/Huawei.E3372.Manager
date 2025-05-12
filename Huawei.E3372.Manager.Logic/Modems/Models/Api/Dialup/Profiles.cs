using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Dialup;

[XmlRoot("response")]
public record ProfilesResponse : IModemGetResponse
{
    [XmlElement("CurrentProfile")]
    public int CurrentProfile { get; set; }

    [XmlElement("Profiles")]
    public Profiles Profiles { get; set; }
}

public record Profiles
{
    [XmlElement("Profile")]
    public Profile[] Profile { get; set; }
}

public record Profile
{
    [XmlElement("Index")]
    public int Index { get; set; }

    [XmlElement("IsValid")]
    public int IsValid { get; set; }

    [XmlElement("Name")]
    public string Name { get; set; }

    [XmlElement("ApnIsStatic")]
    public int ApnIsStatic { get; set; }

    [XmlElement("ApnName")]
    public string ApnName { get; set; }

    [XmlElement("DialupNum")]
    public string DialupNum { get; set; }

    [XmlElement("Username")]
    public string Username { get; set; }

    [XmlElement("Password")]
    public string Password { get; set; }

    [XmlElement("AuthMode")]
    public int AuthMode { get; set; }

    [XmlElement("IpIsStatic")]
    public int IpIsStatic { get; set; }

    [XmlElement("IpAddress")]
    public string IpAddress { get; set; }

    [XmlElement("Ipv6Address")]
    public string Ipv6Address { get; set; }

    [XmlElement("DnsIsStatic")]
    public int DnsIsStatic { get; set; }

    [XmlElement("PrimaryDns")]
    public string PrimaryDns { get; set; }

    [XmlElement("SecondaryDns")]
    public string SecondaryDns { get; set; }

    [XmlElement("PrimaryIpv6Dns")]
    public string PrimaryIpv6Dns { get; set; }

    [XmlElement("SecondaryIpv6Dns")]
    public string SecondaryIpv6Dns { get; set; }

    [XmlElement("ReadOnly")]
    public int ReadOnly { get; set; }

    [XmlElement("iptype")]
    public int IpType { get; set; }
}