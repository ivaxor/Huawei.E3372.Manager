using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Net;

[XmlRoot("response")]
public record RegisterResponse : IModemGetResponse
{
    [XmlElement("Mode")]
    public int Mode { get; init; }

    [XmlElement("Plmn")]
    public string Plmn { get; init; }

    [XmlElement("Rat")]
    public string Rat { get; init; }
}