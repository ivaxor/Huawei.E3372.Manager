using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Security;

[XmlRoot("response")]
public record VirtualServersResponse : IModemGetResponse
{
    [XmlElement("Servers")]
    public VirtualServers Servers { get; set; }
}

public record VirtualServers
{
    // TODO: Test and insert fields
}