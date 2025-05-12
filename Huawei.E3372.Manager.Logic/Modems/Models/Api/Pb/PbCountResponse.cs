using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Pb;

[XmlRoot("response")]
public record PbCountResponse : IModemGetResponse
{
    [XmlElement("LocalUsed")]
    public int LocalUsed { get; set; }

    [XmlElement("SimUsed")]
    public int SimUsed { get; set; }

    [XmlElement("LocalMax")]
    public int LocalMax { get; set; }

    [XmlElement("SimMax")]
    public int SimMax { get; set; }
}