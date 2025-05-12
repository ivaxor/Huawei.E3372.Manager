using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Monitoring;

[XmlRoot("response")]
public record StartDateResponse : IModemGetResponse
{
    [XmlElement("StartDay")]
    public int StartDay { get; set; }

    [XmlElement("DataLimit")]
    public string DataLimit { get; set; }

    [XmlElement("DataLimitAwoke")]
    public int DataLimitAwoke { get; set; }

    [XmlElement("MonthThreshold")]
    public int MonthThreshold { get; set; }

    [XmlElement("MonthThresholdSecond")]
    public int MonthThresholdSecond { get; set; }

    [XmlElement("SetMonthData")]
    public int SetMonthData { get; set; }

    [XmlElement("trafficmaxlimit")]
    public int TrafficMaxLimit { get; set; }

    [XmlElement("turnoffdataenable")]
    public int TurnOffDataEnable { get; set; }

    [XmlElement("turnoffdataswitch")]
    public int TurnOffDataSwitch { get; set; }

    [XmlElement("turnoffdataflag")]
    public int TurnOffDataFlag { get; set; }
}