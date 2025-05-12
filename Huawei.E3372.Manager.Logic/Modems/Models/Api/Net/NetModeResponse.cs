using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Net;

[XmlRoot("response")]
public record NetModeResponse : IModemGetResponse
{
    [XmlElement("NetworkMode")]
    public string NetworkMode { get; set; }

    [XmlElement("NetworkBand")]
    public string NetworkBand { get; set; }

    [XmlElement("LTEBand")]
    public string LTEBand { get; set; }
}