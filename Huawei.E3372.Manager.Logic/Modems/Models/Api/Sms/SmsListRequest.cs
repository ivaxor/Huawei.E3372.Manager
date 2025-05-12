using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Sms;

[XmlRoot("request")]
public record SmsListRequest : IModemPostRequest
{
    [XmlElement("PageIndex")]
    public int PageIndex { get; set; }

    [XmlElement("ReadCount")]
    public int ReadCount { get; set; }

    [XmlElement("BoxType")]
    public int BoxType { get; set; }

    [XmlElement("SortType")]
    public int SortType { get; set; }

    [XmlElement("Ascending")]
    public bool Ascending { get; set; }

    [XmlElement("UnreadPreferred")]
    public bool UnreadPreferred { get; set; }
}