using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Net;

[XmlRoot("response")]
public record RegisterResponse : IModemGetResponse
{
    [XmlElement("Mode")]
    public int Mode { get; set; }

    [XmlElement("Plmn")]
    public string Plmn { get; set; }

    [XmlElement("Rat")]
    public string Rat { get; set; }
}