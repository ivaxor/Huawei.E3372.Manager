using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem;

[XmlRoot("response")]
public record OperatorResponse : IModemGetResponse
{
    [XmlElement("State")]
    public required int State { get; init; }

    [XmlElement("FullName")]
    public required string FullName { get; init; }

    [XmlElement("ShortName")]
    public required string ShortName { get; init; }

    [XmlElement("SIMName")]
    public required string SIMName { get; init; }

    [XmlElement("Numeric")]
    public required string Numeric { get; init; }

    [XmlElement("Rat")]
    public required int Rat { get; init; }
}