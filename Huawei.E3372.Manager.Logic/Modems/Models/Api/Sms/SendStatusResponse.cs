using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Sms;

[XmlRoot("response")]
public record SendStatusResponse : IModemGetResponse
{
    [XmlElement("Phone")]
    public string? Phone { get; init; }

    [XmlElement("SucPhone")]
    public string? SuccessPhone { get; init; }

    [XmlElement("FailPhone")]
    public string? FailPhone { get; init; }

    [XmlElement("TotalCount")]
    public int TotalCount { get; init; }

    [XmlElement("CurIndex")]
    public int CurIndex { get; init; }
}