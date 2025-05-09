using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem;

[XmlRoot("response")]
public record FactoryReset : IModemGetResponse
{
    [XmlText]
    public string? Value { get; init; }
}