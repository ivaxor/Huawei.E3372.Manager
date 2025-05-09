using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Monitoring;

[XmlRoot("response")]
public record StatusResponse : IModemGetResponse
{
    [XmlElement("ConnectionStatus")]
    public required int ConnectionStatus { get; init; }

    [XmlElement("WifiConnectionStatus")]
    public required string WiFiConnectionStatus { get; init; }

    [XmlElement("SignalStrength")]
    public required string SignalStrength { get; init; }

    [XmlElement("SignalIcon")]
    public required int SignalIcon { get; init; }

    [XmlElement("CurrentNetworkType")]
    public required int CurrentNetworkType { get; init; }

    [XmlElement("CurrentServiceDomain")]
    public required int CurrentServiceDomain { get; init; }

    [XmlElement("RoamingStatus")]
    public required int RoamingStatus { get; init; }

    [XmlElement("BatteryStatus")]
    public required string BatteryStatus { get; init; }

    [XmlElement("BatteryLevel")]
    public required string BatteryLevel { get; init; }

    [XmlElement("BatteryPercent")]
    public required string BatteryPercent { get; init; }

    [XmlElement("simlockStatus")]
    public required int SimlockStatus { get; init; }

    [XmlElement("PrimaryDns")]
    public required string PrimaryDns { get; init; }

    [XmlElement("SecondaryDns")]
    public required string SecondaryDns { get; init; }

    [XmlElement("PrimaryIPv6Dns")]
    public required string PrimaryIPv6Dns { get; init; }

    [XmlElement("SecondaryIPv6Dns")]
    public required string SecondaryIPv6Dns { get; init; }

    [XmlElement("CurrentWifiUser")]
    public required string CurrentWiFiUser { get; init; }

    [XmlElement("TotalWifiUser")]
    public required string TotalWiFiUser { get; init; }

    [XmlElement("currenttotalwifiuser")]
    public required int CurrentTotalWiFiUser { get; init; }

    [XmlElement("ServiceStatus")]
    public required int ServiceStatus { get; init; }

    [XmlElement("SimStatus")]
    public required int SimStatus { get; init; }

    [XmlElement("WifiStatus")]
    public required string WiFiStatus { get; init; }

    [XmlElement("CurrentNetworkTypeEx")]
    public required int CurrentNetworkTypeEx { get; init; }

    [XmlElement("maxsignal")]
    public required int MaxSignal { get; init; }

    [XmlElement("wifiindooronly")]
    public required int WiFiIndoorOnly { get; init; }

    [XmlElement("wififrequence")]
    public required int WiFifrequence { get; init; }

    [XmlElement("classify")]
    public required string Classify { get; init; }

    [XmlElement("flymode")]
    public required int FlyMode { get; init; }

    [XmlElement("cellroam")]
    public required int CellRoaming { get; init; }

    [XmlElement("ltecastatus")]
    public required int LteCaStatus { get; init; }
}