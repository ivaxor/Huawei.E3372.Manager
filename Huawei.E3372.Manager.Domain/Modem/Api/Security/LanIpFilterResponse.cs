using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Security;

[XmlRoot("response")]
public record LanIpFilterResponse : IModemGetResponse
{
    [XmlElement("IPFilters")]
    public required LanIpFilter Filter { get; init; }
}

public record LanIpFilter
{
    // TODO: Test and insert fields
}