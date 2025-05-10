using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Monitoring;

[XmlRoot("response")]
public record StartDateResponse : IModemGetResponse
{
    [XmlElement("StartDay")]
    public int StartDay { get; init; }

    [XmlElement("DataLimit")]
    public string DataLimit { get; init; }

    [XmlElement("DataLimitAwoke")]
    public int DataLimitAwoke { get; init; }

    [XmlElement("MonthThreshold")]
    public int MonthThreshold { get; init; }

    [XmlElement("MonthThresholdSecond")]
    public int MonthThresholdSecond { get; init; }

    [XmlElement("SetMonthData")]
    public int SetMonthData { get; init; }

    [XmlElement("trafficmaxlimit")]
    public int TrafficMaxLimit { get; init; }

    [XmlElement("turnoffdataenable")]
    public int TurnOffDataEnable { get; init; }

    [XmlElement("turnoffdataswitch")]
    public int TurnOffDataSwitch { get; init; }

    [XmlElement("turnoffdataflag")]
    public int TurnOffDataFlag { get; init; }
}