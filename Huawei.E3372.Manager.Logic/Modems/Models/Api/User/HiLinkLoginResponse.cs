using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.User;

[XmlRoot("response")]
public record HiLinkLoginResponse : IModemGetResponse
{
    [XmlElement("hilink_login")]
    public bool HiLinkLogin { get; init; }
}