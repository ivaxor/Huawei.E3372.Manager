using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Config.Global;

[XmlRoot("config")]
public record ConfigResponse : IModemGetResponse
{
    [XmlElement("homepage")]
    public string Homepage { get; set; }

    [XmlElement("default_language")]
    public string DefaultLanguage { get; set; }

    [XmlElement("dialogdisapear")]
    public int DialogDisapear { get; set; }

    [XmlElement("tip_disapear")]
    public int TipDisapear { get; set; }

    [XmlElement("update_interval")]
    public int UpdateInterval { get; set; }

    [XmlElement("ap_station_enabled")]
    public bool ApStationEnabled { get; set; }

    [XmlElement("title")]
    public string Title { get; set; }

    [XmlElement("login")]
    public int Login { get; set; }

    [XmlElement("autoapn_enabled")]
    public bool AutoApnEnabled { get; set; }

    [XmlElement("footer")]
    public bool Footer { get; set; }

    [XmlElement("battery_enabled")]
    public bool BatteryEnabled { get; set; }

    [XmlElement("continue_button")]
    public bool ContinueButton { get; set; }

    [XmlElement("special_redirect")]
    public bool SpecialRedirect { get; set; }

    [XmlElement("menu_number")]
    public int MenuNumber { get; set; }

    [XmlElement("special_debug_page")]
    public bool SpecialDebugPage { get; set; }

    [XmlElement("roam_warn_enabled")]
    public bool RoamWarnEnabled { get; set; }

    [XmlElement("hotlinks")]
    public ConfigHotlinks Hotlinks { get; set; }

    [XmlElement("appmanagements")]
    public ConfigAppmanagements AppManagements { get; set; }

    [XmlElement("connection")]
    public ConfigConnection Connection { get; set; }

    [XmlElement("position_info")]
    public ConfigPositionInfo PositionInfo { get; set; }

    [XmlElement("menu")]
    public ConfigMenu Menu { get; set; }

    [XmlElement("copyright")]
    public int Copyright { get; set; }
}

public record ConfigHotlinks
{
    [XmlElement("enable")]
    public bool Enable { get; set; }

    [XmlElement("items")]
    public ConfigHotlinksItems Items { get; set; }
}

public record ConfigHotlinksItems
{
    [XmlElement("item")]
    public string[] Items { get; set; }
}

public record ConfigAppmanagements
{
    [XmlElement("enabled")]
    public bool Enabled { get; set; }

    [XmlElement("hilink")]
    public ConfigAppmanagementsHilink HiLink { get; set; }

    [XmlElement("mobileDoctor")]
    public ConfigAppmanagementsMobileDoctor MobileDoctor { get; set; }
}

public record ConfigAppmanagementsHilink
{
    [XmlElement("domestic")]
    public string Domestic { get; set; }

    [XmlElement("foreign")]
    public string Foreign { get; set; }
}

public record ConfigAppmanagementsMobileDoctor
{
    [XmlElement("windowsOS")]
    public string WindowsOS { get; set; }

    [XmlElement("macOS")]
    public string MacOS { get; set; }

    [XmlElement("linuxOS")]
    public string LinuxOS { get; set; }

    [XmlElement("archlinuxOS")]
    public string ArchLinuxOS { get; set; }

    [XmlElement("debianGNULinuxOS")]
    public string DebianGNULinuxOS { get; set; }

    [XmlElement("appImage32ForLinuxOS")]
    public string AppImage32ForLinuxOS { get; set; }

    [XmlElement("appImage64ForLinuxOS")]
    public string AppImage64ForLinuxOS { get; set; }

    [XmlElement("snapPackage32ForLinuxOS")]
    public string SnapPackage32ForLinuxOS { get; set; }

    [XmlElement("snapPackage64ForLinuxOS")]
    public string SnapPackage64ForLinuxOS { get; set; }

    [XmlElement("otherOS")]
    public string OtherOS { get; set; }
}

public record ConfigConnection
{
    [XmlElement("enable")]
    public bool Enable { get; set; }

    [XmlElement("connectionstatus")]
    public int ConnectionStatus { get; set; }
}

public record ConfigPositionInfo
{
    [XmlElement("offset")]
    public int Offset { get; set; }

    [XmlElement("offset_ie6")]
    public int OffsetIe6 { get; set; }
}

public record ConfigMenu
{
    [XmlElement("home")]
    public string Home { get; set; }

    [XmlElement("antennapointing")]
    public string AntennaPointing { get; set; }

    [XmlElement("statistic")]
    public string Statistic { get; set; }

    [XmlElement("sms")]
    public ConfigMenuSms Sms { get; set; }

    [XmlElement("pb")]
    public string Pb { get; set; }

    [XmlElement("update")]
    public string Update { get; set; }

    [XmlElement("sharing")]
    public ConfigMenuSharing Sharing { get; set; }

    [XmlElement("ussd")]
    public ConfigMenuUssd Ussd { get; set; }

    [XmlElement("mods")]
    public string Mods { get; set; }

    [XmlElement("settings")]
    public ConfigMenuSettings Settings { get; set; }

    [XmlElement("stk")]
    public string Stk { get; set; }

    [XmlElement("appmanagement")]
    public string AppManagement { get; set; }
}

public record ConfigMenuSms
{
    [XmlElement("inbox")]
    public string Inbox { get; set; }

    [XmlElement("sent")]
    public string Sent { get; set; }

    [XmlElement("drafts")]
    public string Drafts { get; set; }

    [XmlElement("sms_center_number")]
    public string SmsCenterNumber { get; set; }
}

public record ConfigMenuSharing
{
    [XmlElement("sdcardsharing")]
    public string SdCardSharing { get; set; }

    [XmlElement("sambasettings")]
    public string SambaSettings { get; set; }

    [XmlElement("sambasharinguser")]
    public string SambaSharingUser { get; set; }

    [XmlElement("dlna")]
    public string Dlna { get; set; }
}

public record ConfigMenuUssd
{
    [XmlElement("prepaid")]
    public ConfigUssdPrepaid Prepaid { get; set; }
}

public record ConfigUssdPrepaid
{
    [XmlElement("pre_fun_balanceInquiry")]
    public string PreFunBalanceInquiry { get; set; }

    [XmlElement("pre_fun_general")]
    public string PreFunGeneral { get; set; }
}

public record ConfigMenuSettings
{
    [XmlElement("quick_setup")]
    public string QuickSetup { get; set; }

    [XmlElement("dialup")]
    public ConfigMenuSettingsDialup Dialup { get; set; }

    [XmlElement("internet")]
    public ConfigMenuSettingsInternet Internet { get; set; }

    [XmlElement("wlan")]
    public ConfigMenuSettingsWlan Wlan { get; set; }

    [XmlElement("security")]
    public ConfigMenuSettingsSecurity Security { get; set; }

    [XmlElement("cbssettings")]
    public string CbsSettings { get; set; }

    [XmlElement("system")]
    public ConfigMenuSettingsSystem System { get; set; }

    [XmlElement("setting_update")]
    public string SettingUpdate { get; set; }
}

public record ConfigMenuSettingsDialup
{
    [XmlElement("mobileconnection")]
    public string MobileConnection { get; set; }

    [XmlElement("profilesmgr")]
    public string ProfilesMgr { get; set; }

    [XmlElement("autoimei")]
    public string AutoImei { get; set; }

    [XmlElement("mobilenetworksettings")]
    public string MobileNetworkSettings { get; set; }
}

public record ConfigMenuSettingsInternet
{
    [XmlElement("wifinetworks")]
    public string WiFiNetworks { get; set; }

    [XmlElement("wifipriority")]
    public string WiFiPriority { get; set; }

    [XmlElement("stationwps")]
    public string StationWps { get; set; }
}

public record ConfigMenuSettingsWlan
{
    [XmlElement("wlanbasicsettings")]
    public string WlanBasicSettings { get; set; }

    [XmlElement("wlanadvanced")]
    public string WlanAdvanced { get; set; }

    [XmlElement("wlanmacfilter")]
    public string WlanMacFilter { get; set; }

    [XmlElement("wps")]
    public string Wps { get; set; }
}

public record ConfigMenuSettingsSecurity
{
    [XmlElement("pincodemanagement")]
    public string PinCodeManagement { get; set; }

    [XmlElement("pincodeautovalidate")]
    public string PinCodeAutoValidate { get; set; }

    [XmlElement("firewallswitch")]
    public string FirewallSwitch { get; set; }

    [XmlElement("lanipfilter")]
    public string LanIpFilter { get; set; }

    [XmlElement("virtualserver")]
    public string VirtualServer { get; set; }

    [XmlElement("specialapplication")]
    public string SpecialApplication { get; set; }

    [XmlElement("dmzsettings")]
    public string DmzSettings { get; set; }

    [XmlElement("sipalgsettings")]
    public string SipalgSettings { get; set; }

    [XmlElement("upnp")]
    public string Upnp { get; set; }

    [XmlElement("nat")]
    public string Nat { get; set; }
}

public record ConfigMenuSettingsSystem
{
    [XmlElement("deviceinformation")]
    public string DeviceInformation { get; set; }

    [XmlElement("dhcp")]
    public string Dhcp { get; set; }

    [XmlElement("hosts")]
    public string Hosts { get; set; }

    [XmlElement("watchcat")]
    public string WatchCat { get; set; }

    [XmlElement("configuration")]
    public string Configuration { get; set; }

    [XmlElement("modifypassword")]
    public string ModifyPassword { get; set; }

    [XmlElement("restore")]
    public string Restore { get; set; }

    [XmlElement("reboot")]
    public string Reboot { get; set; }

    [XmlElement("systemsettings")]
    public string SystemSettings { get; set; }

    [XmlElement("updatesettings")]
    public string UpdateSettings { get; set; }

    [XmlElement("modsettings")]
    public string ModSettings { get; set; }
}