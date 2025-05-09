using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Config.Global;

[XmlRoot("config")]
public record ConfigResponse : IModemGetResponse
{
    [XmlElement("homepage")]
    public required string Homepage { get; init; }

    [XmlElement("default_language")]
    public required string DefaultLanguage { get; init; }

    [XmlElement("dialogdisapear")]
    public required int DialogDisapear { get; init; }

    [XmlElement("tip_disapear")]
    public required int TipDisapear { get; init; }

    [XmlElement("update_interval")]
    public required int UpdateInterval { get; init; }

    [XmlElement("ap_station_enabled")]
    public required int ApStationEnabled { get; init; }

    [XmlElement("title")]
    public required string Title { get; init; }

    [XmlElement("login")]
    public required int Login { get; init; }

    [XmlElement("autoapn_enabled")]
    public required int AutoApnEnabled { get; init; }

    [XmlElement("footer")]
    public required int Footer { get; init; }

    [XmlElement("battery_enabled")]
    public required int BatteryEnabled { get; init; }

    [XmlElement("continue_button")]
    public required int ContinueButton { get; init; }

    [XmlElement("special_redirect")]
    public required int SpecialRedirect { get; init; }

    [XmlElement("menu_number")]
    public required int MenuNumber { get; init; }

    [XmlElement("special_debug_page")]
    public required int SpecialDebugPage { get; init; }

    [XmlElement("roam_warn_enabled")]
    public required int RoamWarnEnabled { get; init; }

    [XmlElement("hotlinks")]
    public required ConfigHotlinks Hotlinks { get; init; }

    [XmlElement("appmanagements")]
    public required ConfigAppmanagements AppManagements { get; init; }

    [XmlElement("connection")]
    public required ConfigConnection Connection { get; init; }

    [XmlElement("position_info")]
    public required ConfigPositionInfo PositionInfo { get; init; }

    [XmlElement("menu")]
    public required ConfigMenu Menu { get; init; }

    [XmlElement("copyright")]
    public required int Copyright { get; init; }
}

public record ConfigHotlinks
{
    [XmlElement("enable")]
    public required int Enable { get; init; }

    [XmlElement("items")]
    public required ConfigHotlinksItems Items { get; init; }
}

public record ConfigHotlinksItems
{
    [XmlElement("item")]
    public required string[] Items { get; init; }
}

public record ConfigAppmanagements
{
    [XmlElement("enabled")]
    public required int Enabled { get; init; }

    [XmlElement("hilink")]
    public required ConfigAppmanagementsHilink HiLink { get; init; }

    [XmlElement("mobileDoctor")]
    public required ConfigAppmanagementsMobileDoctor MobileDoctor { get; init; }
}

public record ConfigAppmanagementsHilink
{
    [XmlElement("domestic")]
    public required string Domestic { get; init; }

    [XmlElement("foreign")]
    public required string Foreign { get; init; }
}

public record ConfigAppmanagementsMobileDoctor
{
    [XmlElement("windowsOS")]
    public required string WindowsOS { get; init; }

    [XmlElement("macOS")]
    public required string MacOS { get; init; }

    [XmlElement("linuxOS")]
    public required string LinuxOS { get; init; }

    [XmlElement("archlinuxOS")]
    public required string ArchLinuxOS { get; init; }

    [XmlElement("debianGNULinuxOS")]
    public required string DebianGNULinuxOS { get; init; }

    [XmlElement("appImage32ForLinuxOS")]
    public required string AppImage32ForLinuxOS { get; init; }

    [XmlElement("appImage64ForLinuxOS")]
    public required string AppImage64ForLinuxOS { get; init; }

    [XmlElement("snapPackage32ForLinuxOS")]
    public required string SnapPackage32ForLinuxOS { get; init; }

    [XmlElement("snapPackage64ForLinuxOS")]
    public required string SnapPackage64ForLinuxOS { get; init; }

    [XmlElement("otherOS")]
    public required string OtherOS { get; init; }
}

public record ConfigConnection
{
    [XmlElement("enable")]
    public required int Enable { get; init; }

    [XmlElement("connectionstatus")]
    public required int ConnectionStatus { get; init; }
}

public record ConfigPositionInfo
{
    [XmlElement("offset")]
    public required int Offset { get; init; }

    [XmlElement("offset_ie6")]
    public required int OffsetIe6 { get; init; }
}

public record ConfigMenu
{
    [XmlElement("home")]
    public required string Home { get; init; }

    [XmlElement("antennapointing")]
    public required string AntennaPointing { get; init; }

    [XmlElement("statistic")]
    public required string Statistic { get; init; }

    [XmlElement("sms")]
    public ConfigMenuSms Sms { get; init; }

    [XmlElement("pb")]
    public required string Pb { get; init; }

    [XmlElement("update")]
    public required string Update { get; init; }

    [XmlElement("sharing")]
    public required ConfigMenuSharing Sharing { get; init; }

    [XmlElement("ussd")]
    public required ConfigMenuUssd Ussd { get; init; }

    [XmlElement("mods")]
    public required string Mods { get; init; }

    [XmlElement("settings")]
    public required ConfigMenuSettings Settings { get; init; }

    [XmlElement("stk")]
    public required string Stk { get; init; }

    [XmlElement("appmanagement")]
    public required string AppManagement { get; init; }
}

public record ConfigMenuSms
{
    [XmlElement("inbox")]
    public required string Inbox { get; init; }

    [XmlElement("sent")]
    public required string Sent { get; init; }

    [XmlElement("drafts")]
    public required string Drafts { get; init; }

    [XmlElement("sms_center_number")]
    public required string SmsCenterNumber { get; init; }
}

public record ConfigMenuSharing
{
    [XmlElement("sdcardsharing")]
    public required string SdCardSharing { get; init; }

    [XmlElement("sambasettings")]
    public required string SambaSettings { get; init; }

    [XmlElement("sambasharinguser")]
    public required string SambaSharingUser { get; init; }

    [XmlElement("dlna")]
    public required string Dlna { get; init; }
}

public record ConfigMenuUssd
{
    [XmlElement("prepaid")]
    public required ConfigUssdPrepaid Prepaid { get; init; }
}

public record ConfigUssdPrepaid
{
    [XmlElement("pre_fun_balanceInquiry")]
    public required string PreFunBalanceInquiry { get; init; }

    [XmlElement("pre_fun_general")]
    public required string PreFunGeneral { get; init; }
}

public record ConfigMenuSettings
{
    [XmlElement("quick_setup")]
    public required string QuickSetup { get; init; }

    [XmlElement("dialup")]
    public required ConfigMenuSettingsDialup Dialup { get; init; }

    [XmlElement("internet")]
    public required ConfigMenuSettingsInternet Internet { get; init; }

    [XmlElement("wlan")]
    public required ConfigMenuSettingsWlan Wlan { get; init; }

    [XmlElement("security")]
    public required ConfigMenuSettingsSecurity Security { get; init; }

    [XmlElement("cbssettings")]
    public required string CbsSettings { get; init; }

    [XmlElement("system")]
    public required ConfigMenuSettingsSystem System { get; init; }

    [XmlElement("setting_update")]
    public required string SettingUpdate { get; init; }
}

public record ConfigMenuSettingsDialup
{
    [XmlElement("mobileconnection")]
    public required string MobileConnection { get; init; }

    [XmlElement("profilesmgr")]
    public required string ProfilesMgr { get; init; }

    [XmlElement("autoimei")]
    public required string AutoImei { get; init; }

    [XmlElement("mobilenetworksettings")]
    public required string MobileNetworkSettings { get; init; }
}

public record ConfigMenuSettingsInternet
{
    [XmlElement("wifinetworks")]
    public required string WiFiNetworks { get; init; }

    [XmlElement("wifipriority")]
    public required string WiFiPriority { get; init; }

    [XmlElement("stationwps")]
    public required string StationWps { get; init; }
}

public record ConfigMenuSettingsWlan
{
    [XmlElement("wlanbasicsettings")]
    public required string WlanBasicSettings { get; init; }

    [XmlElement("wlanadvanced")]
    public required string WlanAdvanced { get; init; }

    [XmlElement("wlanmacfilter")]
    public required string WlanMacFilter { get; init; }

    [XmlElement("wps")]
    public required string Wps { get; init; }
}

public record ConfigMenuSettingsSecurity
{
    [XmlElement("pincodemanagement")]
    public required string PinCodeManagement { get; init; }

    [XmlElement("pincodeautovalidate")]
    public required string PinCodeAutoValidate { get; init; }

    [XmlElement("firewallswitch")]
    public required string FirewallSwitch { get; init; }

    [XmlElement("lanipfilter")]
    public required string LanIpFilter { get; init; }

    [XmlElement("virtualserver")]
    public required string VirtualServer { get; init; }

    [XmlElement("specialapplication")]
    public required string SpecialApplication { get; init; }

    [XmlElement("dmzsettings")]
    public required string DmzSettings { get; init; }

    [XmlElement("sipalgsettings")]
    public required string SipalgSettings { get; init; }

    [XmlElement("upnp")]
    public required string Upnp { get; init; }

    [XmlElement("nat")]
    public required string Nat { get; init; }
}

public record ConfigMenuSettingsSystem
{
    [XmlElement("deviceinformation")]
    public required string DeviceInformation { get; init; }

    [XmlElement("dhcp")]
    public required string Dhcp { get; init; }

    [XmlElement("hosts")]
    public required string Hosts { get; init; }

    [XmlElement("watchcat")]
    public required string WatchCat { get; init; }

    [XmlElement("configuration")]
    public required string Configuration { get; init; }

    [XmlElement("modifypassword")]
    public required string ModifyPassword { get; init; }

    [XmlElement("restore")]
    public required string Restore { get; init; }

    [XmlElement("reboot")]
    public required string Reboot { get; init; }

    [XmlElement("systemsettings")]
    public required string SystemSettings { get; init; }

    [XmlElement("updatesettings")]
    public required string UpdateSettings { get; init; }

    [XmlElement("modsettings")]
    public required string ModSettings { get; init; }
}