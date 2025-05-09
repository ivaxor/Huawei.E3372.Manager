using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Sms;

[XmlRoot("response")]
public record SplitInfoSms : IModemGetResponse
{
    [XmlElement("splitinfo")]
    public int SplitInfo { get; init; }

    [XmlElement("convert_type")]
    public int ConvertType { get; init; }
}