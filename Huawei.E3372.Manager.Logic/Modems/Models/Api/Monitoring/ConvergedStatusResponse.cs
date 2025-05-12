using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Monitoring;

[XmlRoot("response")]
public record ConvergedStatusResponse : IModemGetResponse
{
    [XmlElement("SimState")]
    public int SimState { get; set; }

    [XmlElement("SimLockEnable")]
    public bool SimLockEnable { get; set; }

    [XmlElement("CurrentLanguage")]
    public string CurrentLanguage { get; set; }
}