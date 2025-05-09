using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.User;

[XmlRoot("response")]
public record HiLinkLogin : IModemGetResponse
{
    [XmlElement("hilink_login")]
    public int Login { get; init; }
}