using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Pb;

[XmlRoot("response")]
public record PbListResponse : IModemPostResponse
{
    [XmlElement("SumSize")]
    public bool SumSize { get; set; }

    [XmlElement("Count")]
    public bool Count { get; set; }

    [XmlElement("Phonebooks")]
    public PbListPhonebooks Phonebooks { get; set; }
}

public record PbListPhonebooks
{
    [XmlElement("Phonebook")]
    public PbListPhonebook[] Phonebook { get; set; }
}

public record PbListPhonebook
{
    [XmlElement("GroupID")]
    public bool GroupID { get; set; }

    [XmlElement("Index")]
    public bool Index { get; set; }

    [XmlElement("Field")]
    public PbListPhonebookField[] Field { get; set; }
}

public record PbListPhonebookField
{
    [XmlElement("Name")]
    public string Name { get; set; }

    [XmlElement("Value")]
    public string Value { get; set; }
}