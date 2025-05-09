using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.SdCard;

[XmlRoot("response")]
public record SdCard : IModemGetResponse
{
    [XmlElement("sdcard")]
    public SDCardInfo Info { get; init; }
}

public record SDCardInfo
{
    [XmlElement("SDShareMode")]
    public int ShareMode { get; init; }

    [XmlElement("SDCardShareStatus")]
    public int ShareStatus { get; init; }

    [XmlElement("SDShareFileMode")]
    public int ShareFileMode { get; init; }

    [XmlElement("SDAccessType")]
    public int AccessType { get; init; }

    [XmlElement("SDSharePath")]
    public string? SharePath { get; init; }

    [XmlElement("SDCardStatus")]
    public int Status { get; init; }
}