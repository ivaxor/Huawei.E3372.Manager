using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Stk;

[XmlRoot("response")]
public record StkGetMainResponse : IModemPostResponse
{
    [XmlElement("CmdType")]
    public int CmdType { get; set; }

    [XmlElement("CmdIndex")]
    public int CmdIndex { get; set; }

    [XmlElement("IsTimeout")]
    public int IsTimeout { get; set; }

    [XmlElement("DataTotal")]
    public int DataTotal { get; set; }

    [XmlElement("PageTotal")]
    public int PageTotal { get; set; }

    [XmlElement("PageIndex")]
    public int PageIndex { get; set; }

    [XmlElement("STKData")]
    public StkGetMainData Data { get; set; }
}

public record StkGetMainData
{
    [XmlElement("Field")]
    public StkGetMainDataField[] Fields { get; set; }
}

public record StkGetMainDataField
{
    [XmlElement("Value")]
    public string Value { get; set; }

    [XmlElement("Name")]
    public string Name { get; set; }
}
