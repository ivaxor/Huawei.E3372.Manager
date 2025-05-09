using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Security;

[XmlRoot("response")]
public record SpecialApplicationsResponse : IModemGetResponse
{
    [XmlElement("LanPorts")]
    public required SpecialApplicationsLanPorts LanPorts { get; init; }
}

public record SpecialApplicationsLanPorts
{
    // TOOD: Test and insert fields
}