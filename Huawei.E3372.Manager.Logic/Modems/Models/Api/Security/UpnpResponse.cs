using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Security;

[XmlRoot("response")]
public record UpnpResponse : IModemGetResponse
{
    [XmlElement("UpnpStatus")]
    public bool UpnpStatus { get; init; }
}