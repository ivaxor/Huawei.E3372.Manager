using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Sms;

[XmlRoot("request")]
public record SmsListRequest : IModemPostRequest
{
    [XmlElement("PageIndex")]
    public required bool PageIndex { get; init; }

    [XmlElement("ReadCount")]
    public required bool ReadCount { get; init; }

    [XmlElement("BoxType")]
    public required bool BoxType { get; init; }

    [XmlElement("SortType")]
    public required bool SortType { get; init; }

    [XmlElement("Ascending")]
    public required bool Ascending { get; init; }

    [XmlElement("UnreadPreferred")]
    public required bool UnreadPreferred { get; init; }
}