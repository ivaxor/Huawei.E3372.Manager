using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Security;

[XmlRoot("response")]
public record SpecialApplicationsResponse : IModemGetResponse
{
    [XmlElement("LanPorts")]
    public SpecialApplicationsLanPorts LanPorts { get; init; }
}

public record SpecialApplicationsLanPorts
{
    // TOOD: Test and insert fields
}