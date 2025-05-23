﻿using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Security;

[XmlRoot("response")]
public record SipResponse : IModemGetResponse
{
    [XmlElement("SipStatus")]
    public bool SipStatus { get; set; }

    [XmlElement("SipPort")]
    public int SipPort { get; set; }
}