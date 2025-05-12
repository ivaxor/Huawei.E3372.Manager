using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Security;

[XmlRoot("response")]
public record NatResponse : IModemGetResponse
{
    [XmlElement("NATType")]
    public int NATType { get; set; }
}