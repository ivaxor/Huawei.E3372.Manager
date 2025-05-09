using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Sms;

[XmlRoot("request")]
public record SmsListRequest : IModemPostRequest
{
    [XmlElement("PageIndex")]
    public required int PageIndex { get; init; }

    [XmlElement("ReadCount")]
    public required int ReadCount { get; init; }

    [XmlElement("BoxType")]
    public required int BoxType { get; init; }

    [XmlElement("SortType")]
    public required int SortType { get; init; }

    [XmlElement("Ascending")]
    public required bool Ascending { get; init; }

    [XmlElement("UnreadPreferred")]
    public required bool UnreadPreferred { get; init; }
}