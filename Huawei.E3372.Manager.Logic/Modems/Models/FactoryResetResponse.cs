using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models;

[XmlRoot("response")]
public record FactoryResetResponse : IModemGetResponse
{
    [XmlText]
    public string Value { get; set; }
}