using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.WebServer;

[XmlRoot("response")]
public record SessionTokenInfoResponse : IModemGetResponse
{
    [XmlElement("SesInfo")]

    public string SessionInfo { get; set; }

    [XmlElement("TokInfo")]
    public string TokenInfo { get; set; }
}