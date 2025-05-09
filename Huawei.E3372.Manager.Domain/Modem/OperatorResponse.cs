using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem;

[XmlRoot("response")]
public record OperatorResponse : IModemGetResponse
{
    [XmlElement("State")]
    public int State { get; init; }

    [XmlElement("FullName")]
    public string? FullName { get; init; }

    [XmlElement("ShortName")]
    public string? ShortName { get; init; }

    [XmlElement("SIMName")]
    public string? SIMName { get; init; }

    [XmlElement("Numeric")]
    public string? Numeric { get; init; }

    [XmlElement("Rat")]
    public int Rat { get; init; }
}