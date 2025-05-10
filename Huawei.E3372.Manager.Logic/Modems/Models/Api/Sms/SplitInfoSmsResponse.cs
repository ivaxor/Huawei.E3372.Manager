using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Sms;

[XmlRoot("response")]
public record SplitInfoSmsResponse : IModemGetResponse
{
    [XmlElement("splitinfo")]
    public bool SplitInfo { get; init; }

    [XmlElement("convert_type")]
    public bool ConvertType { get; init; }
}