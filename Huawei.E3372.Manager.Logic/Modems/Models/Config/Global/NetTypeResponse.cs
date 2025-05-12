using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Config.Global;

[XmlRoot("config")]
public record NetTypeResponse : IModemGetResponse
{
    [XmlElement("networktypes")]
    public NetTypeElement[] NetworkTypes { get; set; }
}

public record NetTypeElement
{
    [XmlElement("index")]
    public string Index { get; set; }

    [XmlElement("networktype")]
    public string NetworkType { get; set; }
}