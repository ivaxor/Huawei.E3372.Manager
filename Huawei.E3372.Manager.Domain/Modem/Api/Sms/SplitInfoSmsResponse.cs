using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Sms;

[XmlRoot("response")]
public record SplitInfoSmsResponse : IModemGetResponse
{
    [XmlElement("splitinfo")]
    public required int SplitInfo { get; init; }

    [XmlElement("convert_type")]
    public required int ConvertType { get; init; }
}