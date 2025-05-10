using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Security;

[XmlRoot("response")]
public record DmzResponse : IModemGetResponse
{
    [XmlElement("DmzStatus")]
    public bool DmzStatus { get; init; }

    [XmlElement("DmzIPAddress")]
    public string DmzIPAddress { get; init; }
}