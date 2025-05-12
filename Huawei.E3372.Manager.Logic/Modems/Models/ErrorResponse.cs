using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models;

[XmlRoot("error")]
public record ErrorResponse : IModemGetResponse, IModemPostResponse
{
    [XmlElement("code")]
    public int Code { get; set; }

    [XmlElement("message")]
    public string Message { get; set; }
}