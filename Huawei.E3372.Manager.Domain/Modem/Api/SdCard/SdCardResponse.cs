using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.SdCard;

[XmlRoot("response")]
public record SdCardResponse : IModemGetResponse
{
    [XmlElement("sdcard")]
    public SDCardInfo Info { get; init; }
}

public record SDCardInfo
{
    [XmlElement("SDShareMode")]
    public required int ShareMode { get; init; }

    [XmlElement("SDCardShareStatus")]
    public required int ShareStatus { get; init; }

    [XmlElement("SDShareFileMode")]
    public required int ShareFileMode { get; init; }

    [XmlElement("SDAccessType")]
    public required int AccessType { get; init; }

    [XmlElement("SDSharePath")]
    public required string SharePath { get; init; }

    [XmlElement("SDCardStatus")]
    public required int Status { get; init; }
}