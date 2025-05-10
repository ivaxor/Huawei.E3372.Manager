using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Sms;

[XmlRoot("request")]
public record SmsListRequest : IModemPostRequest
{
    [XmlElement("PageIndex")]
    public int PageIndex { get; init; }

    [XmlElement("ReadCount")]
    public int ReadCount { get; init; }

    [XmlElement("BoxType")]
    public int BoxType { get; init; }

    [XmlElement("SortType")]
    public int SortType { get; init; }

    [XmlElement("Ascending")]
    public bool Ascending { get; init; }

    [XmlElement("UnreadPreferred")]
    public bool UnreadPreferred { get; init; }
}