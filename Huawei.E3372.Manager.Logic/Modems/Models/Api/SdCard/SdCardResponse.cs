using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.SdCard;

[XmlRoot("response")]
public record SdCardResponse : IModemGetResponse
{
    [XmlElement("sdcard")]
    public SDCardInfo Info { get; init; }
}

public record SDCardInfo
{
    [XmlElement("SDShareMode")]
    public bool ShareMode { get; init; }

    [XmlElement("SDCardShareStatus")]
    public bool ShareStatus { get; init; }

    [XmlElement("SDShareFileMode")]
    public bool ShareFileMode { get; init; }

    [XmlElement("SDAccessType")]
    public bool AccessType { get; init; }

    [XmlElement("SDSharePath")]
    public string SharePath { get; init; }

    [XmlElement("SDCardStatus")]
    public bool Status { get; init; }
}