using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Security;

[XmlRoot("response")]
public record LanIpFilterResponse : IModemGetResponse
{
    [XmlElement("IPFilters")]
    public LanIpFilter Filter { get; init; }
}

public record LanIpFilter
{
    // TODO: Test and insert fields
}