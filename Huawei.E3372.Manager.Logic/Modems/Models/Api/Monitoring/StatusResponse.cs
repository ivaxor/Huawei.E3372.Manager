using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Monitoring;

[XmlRoot("response")]
public record StatusResponse : IModemGetResponse
{
    [XmlElement("ConnectionStatus")]
    public int ConnectionStatus { get; set; }

    [XmlElement("WifiConnectionStatus")]
    public string WiFiConnectionStatus { get; set; }

    [XmlElement("SignalStrength")]
    public string SignalStrength { get; set; }

    [XmlElement("SignalIcon")]
    public int SignalIcon { get; set; }

    [XmlElement("CurrentNetworkType")]
    public int CurrentNetworkType { get; set; }

    [XmlElement("CurrentServiceDomain")]
    public int CurrentServiceDomain { get; set; }

    [XmlElement("RoamingStatus")]
    public int RoamingStatus { get; set; }

    [XmlElement("BatteryStatus")]
    public string BatteryStatus { get; set; }

    [XmlElement("BatteryLevel")]
    public string BatteryLevel { get; set; }

    [XmlElement("BatteryPercent")]
    public string BatteryPercent { get; set; }

    [XmlElement("simlockStatus")]
    public int SimlockStatus { get; set; }

    [XmlElement("PrimaryDns")]
    public string PrimaryDns { get; set; }

    [XmlElement("SecondaryDns")]
    public string SecondaryDns { get; set; }

    [XmlElement("PrimaryIPv6Dns")]
    public string PrimaryIPv6Dns { get; set; }

    [XmlElement("SecondaryIPv6Dns")]
    public string SecondaryIPv6Dns { get; set; }

    [XmlElement("CurrentWifiUser")]
    public string CurrentWiFiUser { get; set; }

    [XmlElement("TotalWifiUser")]
    public string TotalWiFiUser { get; set; }

    [XmlElement("currenttotalwifiuser")]
    public int CurrentTotalWiFiUser { get; set; }

    [XmlElement("ServiceStatus")]
    public int ServiceStatus { get; set; }

    [XmlElement("SimStatus")]
    public int SimStatus { get; set; }

    [XmlElement("WifiStatus")]
    public string WiFiStatus { get; set; }

    [XmlElement("CurrentNetworkTypeEx")]
    public int CurrentNetworkTypeEx { get; set; }

    [XmlElement("maxsignal")]
    public int MaxSignal { get; set; }

    [XmlElement("wifiindooronly")]
    public int WiFiIndoorOnly { get; set; }

    [XmlElement("wififrequence")]
    public int WiFiFrequence { get; set; }

    [XmlElement("classify")]
    public string Classify { get; set; }

    [XmlElement("flymode")]
    public int FlyMode { get; set; }

    [XmlElement("cellroam")]
    public int CellRoaming { get; set; }

    [XmlElement("ltecastatus")]
    public int LteCaStatus { get; set; }
}