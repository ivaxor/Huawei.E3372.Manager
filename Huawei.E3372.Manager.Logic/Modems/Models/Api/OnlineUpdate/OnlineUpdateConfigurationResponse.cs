﻿using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.OnlineUpdate;

[XmlRoot("response")]
public record OnlineUpdateConfigurationResponse : IModemGetResponse
{
    [XmlElement("autoUpdateInterval")]
    public int AutoUpdateInterval { get; set; }

    [XmlElement("auto_update_enable")]
    public bool AutoUpdateEnable { get; set; }

    [XmlElement("server_force_enable")]
    public bool ServerForceEnable { get; set; }
}