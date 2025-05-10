using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Pb;

[XmlRoot("response")]
public record PbMatchResponse : IModemPostResponse
{
    [XmlElement("Name")]
    public string[] Names { get; init; }
}