﻿using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Net;

[XmlRoot("response")]
public record SignalParaResponse : IModemGetResponse
{
    [XmlElement("Rscp")]
    public int Rscp { get; init; }

    [XmlElement("Ecio")]
    public int Ecio { get; init; }
}