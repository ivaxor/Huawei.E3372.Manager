using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.User;

[XmlRoot("response")]
public record HiLinkLoginResponse : IModemGetResponse
{
    [XmlElement("hilink_login")]
    public int HiLinkLogin { get; init; }
}