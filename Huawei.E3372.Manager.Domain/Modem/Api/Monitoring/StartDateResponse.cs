using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Monitoring;

[XmlRoot("response")]
public record StartDateResponse : IModemGetResponse
{
    [XmlElement("StartDay")]
    public required int StartDay { get; init; }

    [XmlElement("DataLimit")]
    public required string DataLimit { get; init; }

    [XmlElement("DataLimitAwoke")]
    public required int DataLimitAwoke { get; init; }

    [XmlElement("MonthThreshold")]
    public required int MonthThreshold { get; init; }

    [XmlElement("MonthThresholdSecond")]
    public required int MonthThresholdSecond { get; init; }

    [XmlElement("SetMonthData")]
    public required int SetMonthData { get; init; }

    [XmlElement("trafficmaxlimit")]
    public required int TrafficMaxLimit { get; init; }

    [XmlElement("turnoffdataenable")]
    public required int TurnOffDataEnable { get; init; }

    [XmlElement("turnoffdataswitch")]
    public required int TurnOffDataSwitch { get; init; }

    [XmlElement("turnoffdataflag")]
    public required int TurnOffDataFlag { get; init; }
}