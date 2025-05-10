using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.User;

[XmlRoot("response")]
public record StateLoginResponse : IModemGetResponse
{
    [XmlElement("State")]
    public bool State { get; init; }

    [XmlElement("Username")]
    public string UserName { get; init; }

    [XmlElement("password_type")]
    public bool PasswordType { get; init; }

    [XmlElement("extern_password_type")]
    public bool ExternPasswordType { get; init; }

    [XmlElement("firstlogin")]
    public bool FirstLogin { get; init; }
}