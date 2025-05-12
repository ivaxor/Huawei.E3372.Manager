using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.SdCard;

[XmlRoot("response")]
public record SdCardResponse : IModemGetResponse
{
    [XmlElement("sdcard")]
    public SDCardInfo Info { get; set; }
}

public record SDCardInfo
{
    [XmlElement("SDShareMode")]
    public bool ShareMode { get; set; }

    [XmlElement("SDCardShareStatus")]
    public bool ShareStatus { get; set; }

    [XmlElement("SDShareFileMode")]
    public bool ShareFileMode { get; set; }

    [XmlElement("SDAccessType")]
    public bool AccessType { get; set; }

    [XmlElement("SDSharePath")]
    public string SharePath { get; set; }

    [XmlElement("SDCardStatus")]
    public bool Status { get; set; }
}