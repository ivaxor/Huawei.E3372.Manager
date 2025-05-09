using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Monitoring;

[XmlRoot("response")]
public record StatusResponse : IModemGetResponse
{
    [XmlElement("ConnectionStatus")]
    public int ConnectionStatus { get; init; }

    [XmlElement("WifiConnectionStatus")]
    public string? WiFiConnectionStatus { get; init; }

    [XmlElement("SignalStrength")]
    public string? SignalStrength { get; init; }

    [XmlElement("SignalIcon")]
    public int SignalIcon { get; init; }

    [XmlElement("CurrentNetworkType")]
    public int CurrentNetworkType { get; init; }

    [XmlElement("CurrentServiceDomain")]
    public int CurrentServiceDomain { get; init; }

    [XmlElement("RoamingStatus")]
    public int RoamingStatus { get; init; }

    [XmlElement("BatteryStatus")]
    public string? BatteryStatus { get; init; }

    [XmlElement("BatteryLevel")]
    public string? BatteryLevel { get; init; }

    [XmlElement("BatteryPercent")]
    public string? BatteryPercent { get; init; }

    [XmlElement("simlockStatus")]
    public int SimlockStatus { get; init; }

    [XmlElement("PrimaryDns")]
    public string? PrimaryDns { get; init; }

    [XmlElement("SecondaryDns")]
    public string? SecondaryDns { get; init; }

    [XmlElement("PrimaryIPv6Dns")]
    public string? PrimaryIPv6Dns { get; init; }

    [XmlElement("SecondaryIPv6Dns")]
    public string? SecondaryIPv6Dns { get; init; }

    [XmlElement("CurrentWifiUser")]
    public string? CurrentWiFiUser { get; init; }

    [XmlElement("TotalWifiUser")]
    public string? TotalWiFiUser { get; init; }

    [XmlElement("currenttotalwifiuser")]
    public int CurrentTotalWiFiUser { get; init; }

    [XmlElement("ServiceStatus")]
    public int ServiceStatus { get; init; }

    [XmlElement("SimStatus")]
    public int SimStatus { get; init; }

    [XmlElement("WifiStatus")]
    public string? WiFiStatus { get; init; }

    [XmlElement("CurrentNetworkTypeEx")]
    public int CurrentNetworkTypeEx { get; init; }

    [XmlElement("maxsignal")]
    public int MaxSignal { get; init; }

    [XmlElement("wifiindooronly")]
    public int WiFiIndoorOnly { get; init; }

    [XmlElement("wififrequence")]
    public int WiFifrequence { get; init; }

    [XmlElement("classify")]
    public string? Classify { get; init; }

    [XmlElement("flymode")]
    public int FlyMode { get; init; }

    [XmlElement("cellroam")]
    public int CellRoaming { get; init; }

    [XmlElement("ltecastatus")]
    public int LteCaStatus { get; init; }
}