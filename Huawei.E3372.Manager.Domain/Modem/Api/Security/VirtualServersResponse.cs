using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Security;

[XmlRoot("response")]
public record VirtualServersResponse : IModemGetResponse
{
    [XmlElement("Servers")]
    public required VirtualServers Servers { get; init; }
}

public record VirtualServers
{
    // TODO: Test and insert fields
}