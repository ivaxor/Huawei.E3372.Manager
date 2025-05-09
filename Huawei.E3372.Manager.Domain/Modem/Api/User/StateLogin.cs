using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem;

[XmlRoot("response")]
public record StateLogin : IModemGetResponse
{
    [XmlElement("State")]
    public int State { get; init; }

    [XmlElement("Username")]
    public string? UserName { get; init; }

    [XmlElement("password_type")]
    public int PasswordType { get; init; }

    [XmlElement("extern_password_type")]
    public int ExternPasswordType { get; init; }

    [XmlElement("firstlogin")]
    public int FirstLogin { get; init; }
}