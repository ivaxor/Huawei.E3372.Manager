using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Sms;

[XmlRoot("response")]
public record SplitInfoSmsResponse : IModemGetResponse
{
    [XmlElement("splitinfo")]
    public required bool SplitInfo { get; init; }

    [XmlElement("convert_type")]
    public required bool ConvertType { get; init; }
}