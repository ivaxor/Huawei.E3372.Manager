using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models;

[XmlRoot("response")]
public record OperatorResponse : IModemGetResponse
{
    [XmlElement("State")]
    public int State { get; set; }

    [XmlElement("FullName")]
    public string FullName { get; set; }

    [XmlElement("ShortName")]
    public string ShortName { get; set; }

    [XmlElement("SIMName")]
    public string SIMName { get; set; }

    [XmlElement("Numeric")]
    public string Numeric { get; set; }

    [XmlElement("Rat")]
    public int Rat { get; set; }
}