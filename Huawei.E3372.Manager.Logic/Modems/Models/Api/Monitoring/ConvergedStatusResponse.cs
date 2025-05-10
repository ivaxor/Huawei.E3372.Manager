using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Monitoring;

[XmlRoot("response")]
public record ConvergedStatusResponse : IModemGetResponse
{
    [XmlElement("SimState")]
    public int SimState { get; init; }

    [XmlElement("SimLockEnable")]
    public bool SimLockEnable { get; init; }

    [XmlElement("CurrentLanguage")]
    public string CurrentLanguage { get; init; }
}