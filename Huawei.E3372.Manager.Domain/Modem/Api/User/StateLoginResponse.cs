using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem;

[XmlRoot("response")]
public record StateLoginResponse : IModemGetResponse
{
    [XmlElement("State")]
    public required int State { get; init; }

    [XmlElement("Username")]
    public required string UserName { get; init; }

    [XmlElement("password_type")]
    public required int PasswordType { get; init; }

    [XmlElement("extern_password_type")]
    public required int ExternPasswordType { get; init; }

    [XmlElement("firstlogin")]
    public required int FirstLogin { get; init; }
}