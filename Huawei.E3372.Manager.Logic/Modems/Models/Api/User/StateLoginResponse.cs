using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.User;

[XmlRoot("response")]
public record StateLoginResponse : IModemGetResponse
{
    [XmlElement("State")]
    public bool State { get; set; }

    [XmlElement("Username")]
    public string UserName { get; set; }

    [XmlElement("password_type")]
    public bool PasswordType { get; set; }

    [XmlElement("extern_password_type")]
    public bool ExternPasswordType { get; set; }

    [XmlElement("firstlogin")]
    public bool FirstLogin { get; set; }
}