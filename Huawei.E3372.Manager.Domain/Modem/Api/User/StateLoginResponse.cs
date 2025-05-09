using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.User;

[XmlRoot("response")]
public record StateLoginResponse : IModemGetResponse
{
    [XmlElement("State")]
    public required bool State { get; init; }

    [XmlElement("Username")]
    public required string UserName { get; init; }

    [XmlElement("password_type")]
    public required bool PasswordType { get; init; }

    [XmlElement("extern_password_type")]
    public required bool ExternPasswordType { get; init; }

    [XmlElement("firstlogin")]
    public required bool FirstLogin { get; init; }
}