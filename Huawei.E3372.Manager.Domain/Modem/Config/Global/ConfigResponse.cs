using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Config.Global;

[XmlRoot("config")]
public record ConfigResponse : IModemGetResponse
{
    [XmlElement("homepage")]
    public string? Homepage { get; init; }

    [XmlElement("default_language")]
    public string? DefaultLanguage { get; init; }

    [XmlElement("dialogdisapear")]
    public int DialogDisapear { get; init; }

    [XmlElement("tip_disapear")]
    public int TipDisapear { get; init; }

    [XmlElement("update_interval")]
    public int UpdateInterval { get; init; }

    [XmlElement("ap_station_enabled")]
    public int ApStationEnabled { get; init; }

    [XmlElement("title")]
    public string? Title { get; init; }

    [XmlElement("login")]
    public int Login { get; init; }

    [XmlElement("autoapn_enabled")]
    public int AutoApnEnabled { get; init; }

    [XmlElement("footer")]
    public int Footer { get; init; }

    [XmlElement("battery_enabled")]
    public int BatteryEnabled { get; init; }

    [XmlElement("continue_button")]
    public int ContinueButton { get; init; }

    [XmlElement("special_redirect")]
    public int SpecialRedirect { get; init; }

    [XmlElement("menu_number")]
    public int MenuNumber { get; init; }

    [XmlElement("special_debug_page")]
    public int SpecialDebugPage { get; init; }

    [XmlElement("roam_warn_enabled")]
    public int RoamWarnEnabled { get; init; }

    [XmlElement("hotlinks")]
    public ConfigHotlinks Hotlinks { get; init; }

    [XmlElement("appmanagements")]
    public ConfigAppmanagements AppManagements { get; init; }

    [XmlElement("connection")]
    public ConfigConnection Connection { get; init; }

    [XmlElement("position_info")]
    public ConfigPositionInfo PositionInfo { get; init; }

    [XmlElement("menu")]
    public ConfigMenu Menu { get; init; }

    [XmlElement("copyright")]
    public int Copyright { get; init; }
}

public record ConfigHotlinks
{
    [XmlElement("enable")]
    public int Enable { get; init; }

    [XmlElement("items")]
    public ConfigHotlinksItems Items { get; init; }
}

public record ConfigHotlinksItems
{
    [XmlElement("item")]
    public List<string?> Item { get; init; }
}

public record ConfigAppmanagements
{
    [XmlElement("enabled")]
    public int Enabled { get; init; }

    [XmlElement("hilink")]
    public ConfigAppmanagementsHilink HiLink { get; init; }

    [XmlElement("mobileDoctor")]
    public ConfigAppmanagementsMobileDoctor MobileDoctor { get; init; }
}

public record ConfigAppmanagementsHilink
{
    [XmlElement("domestic")]
    public string? Domestic { get; init; }

    [XmlElement("foreign")]
    public string? Foreign { get; init; }
}

public record ConfigAppmanagementsMobileDoctor
{
    [XmlElement("windowsOS")]
    public string? WindowsOS { get; init; }

    [XmlElement("macOS")]
    public string? MacOS { get; init; }

    [XmlElement("linuxOS")]
    public string? LinuxOS { get; init; }

    [XmlElement("archlinuxOS")]
    public string? ArchLinuxOS { get; init; }

    [XmlElement("debianGNULinuxOS")]
    public string? DebianGNULinuxOS { get; init; }

    [XmlElement("appImage32ForLinuxOS")]
    public string? AppImage32ForLinuxOS { get; init; }

    [XmlElement("appImage64ForLinuxOS")]
    public string? AppImage64ForLinuxOS { get; init; }

    [XmlElement("snapPackage32ForLinuxOS")]
    public string? SnapPackage32ForLinuxOS { get; init; }

    [XmlElement("snapPackage64ForLinuxOS")]
    public string? SnapPackage64ForLinuxOS { get; init; }

    [XmlElement("otherOS")]
    public string? OtherOS { get; init; }
}

public record ConfigConnection
{
    [XmlElement("enable")]
    public int Enable { get; init; }

    [XmlElement("connectionstatus")]
    public int ConnectionStatus { get; init; }
}

public record ConfigPositionInfo
{
    [XmlElement("offset")]
    public int Offset { get; init; }

    [XmlElement("offset_ie6")]
    public int OffsetIe6 { get; init; }
}

public record ConfigMenu
{
    [XmlElement("home")]
    public string? Home { get; init; }

    [XmlElement("antennapointing")]
    public string? AntennaPointing { get; init; }

    [XmlElement("statistic")]
    public string? Statistic { get; init; }

    [XmlElement("sms")]
    public ConfigMenuSms Sms { get; init; }

    [XmlElement("pb")]
    public string? Pb { get; init; }

    [XmlElement("update")]
    public string? Update { get; init; }

    [XmlElement("sharing")]
    public ConfigMenuSharing Sharing { get; init; }

    [XmlElement("ussd")]
    public ConfigMenuUssd Ussd { get; init; }

    [XmlElement("mods")]
    public string? Mods { get; init; }

    [XmlElement("settings")]
    public ConfigMenuSettings Settings { get; init; }

    [XmlElement("stk")]
    public string? Stk { get; init; }

    [XmlElement("appmanagement")]
    public string? AppManagement { get; init; }
}

public record ConfigMenuSms
{
    [XmlElement("inbox")]
    public string? Inbox { get; init; }

    [XmlElement("sent")]
    public string? Sent { get; init; }

    [XmlElement("drafts")]
    public string? Drafts { get; init; }

    [XmlElement("sms_center_number")]
    public string? SmsCenterNumber { get; init; }
}

public record ConfigMenuSharing
{
    [XmlElement("sdcardsharing")]
    public string? SdCardSharing { get; init; }

    [XmlElement("sambasettings")]
    public string? SambaSettings { get; init; }

    [XmlElement("sambasharinguser")]
    public string? SambaSharingUser { get; init; }

    [XmlElement("dlna")]
    public string? Dlna { get; init; }
}

public record ConfigMenuUssd
{
    [XmlElement("prepaid")]
    public ConfigUssdPrepaid Prepaid { get; init; }
}

public record ConfigUssdPrepaid
{
    [XmlElement("pre_fun_balanceInquiry")]
    public string? PreFunBalanceInquiry { get; init; }

    [XmlElement("pre_fun_general")]
    public string? PreFunGeneral { get; init; }
}

public record ConfigMenuSettings
{
    [XmlElement("quick_setup")]
    public string? QuickSetup { get; init; }

    [XmlElement("dialup")]
    public ConfigMenuSettingsDialup Dialup { get; init; }

    [XmlElement("internet")]
    public ConfigMenuSettingsInternet Internet { get; init; }

    [XmlElement("wlan")]
    public ConfigMenuSettingsWlan Wlan { get; init; }

    [XmlElement("security")]
    public ConfigMenuSettingsSecurity Security { get; init; }

    [XmlElement("cbssettings")]
    public string? CbsSettings { get; init; }

    [XmlElement("system")]
    public ConfigMenuSettingsSystem System { get; init; }

    [XmlElement("setting_update")]
    public string? SettingUpdate { get; init; }
}

public record ConfigMenuSettingsDialup
{
    [XmlElement("mobileconnection")]
    public string? MobileConnection { get; init; }

    [XmlElement("profilesmgr")]
    public string? ProfilesMgr { get; init; }

    [XmlElement("autoimei")]
    public string? AutoImei { get; init; }

    [XmlElement("mobilenetworksettings")]
    public string? MobileNetworkSettings { get; init; }
}

public record ConfigMenuSettingsInternet
{
    [XmlElement("wifinetworks")]
    public string? WiFiNetworks { get; init; }

    [XmlElement("wifipriority")]
    public string? WiFiPriority { get; init; }

    [XmlElement("stationwps")]
    public string? StationWps { get; init; }
}

public record ConfigMenuSettingsWlan
{
    [XmlElement("wlanbasicsettings")]
    public string? WlanBasicSettings { get; init; }

    [XmlElement("wlanadvanced")]
    public string? WlanAdvanced { get; init; }

    [XmlElement("wlanmacfilter")]
    public string? WlanMacFilter { get; init; }

    [XmlElement("wps")]
    public string? Wps { get; init; }
}

public record ConfigMenuSettingsSecurity
{
    [XmlElement("pincodemanagement")]
    public string? PinCodeManagement { get; init; }

    [XmlElement("pincodeautovalidate")]
    public string? PinCodeAutoValidate { get; init; }

    [XmlElement("firewallswitch")]
    public string? FirewallSwitch { get; init; }

    [XmlElement("lanipfilter")]
    public string? LanIpFilter { get; init; }

    [XmlElement("virtualserver")]
    public string? VirtualServer { get; init; }

    [XmlElement("specialapplication")]
    public string? SpecialApplication { get; init; }

    [XmlElement("dmzsettings")]
    public string? DmzSettings { get; init; }

    [XmlElement("sipalgsettings")]
    public string? SipalgSettings { get; init; }

    [XmlElement("upnp")]
    public string? Upnp { get; init; }

    [XmlElement("nat")]
    public string? Nat { get; init; }
}

public record ConfigMenuSettingsSystem
{
    [XmlElement("deviceinformation")]
    public string? DeviceInformation { get; init; }

    [XmlElement("dhcp")]
    public string? Dhcp { get; init; }

    [XmlElement("hosts")]
    public string? Hosts { get; init; }

    [XmlElement("watchcat")]
    public string? WatchCat { get; init; }

    [XmlElement("configuration")]
    public string? Configuration { get; init; }

    [XmlElement("modifypassword")]
    public string? ModifyPassword { get; init; }

    [XmlElement("restore")]
    public string? Restore { get; init; }

    [XmlElement("reboot")]
    public string? Reboot { get; init; }

    [XmlElement("systemsettings")]
    public string? SystemSettings { get; init; }

    [XmlElement("updatesettings")]
    public string? UpdateSettings { get; init; }

    [XmlElement("modsettings")]
    public string? ModSettings { get; init; }
}