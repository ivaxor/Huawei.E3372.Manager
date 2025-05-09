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
    public required bool ShareMode { get; init; }

    [XmlElement("SDCardShareStatus")]
    public required bool ShareStatus { get; init; }

    [XmlElement("SDShareFileMode")]
    public required bool ShareFileMode { get; init; }

    [XmlElement("SDAccessType")]
    public required bool AccessType { get; init; }

    [XmlElement("SDSharePath")]
    public required string SharePath { get; init; }

    [XmlElement("SDCardStatus")]
    public required bool Status { get; init; }
}