using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Logic.Modems.Models.Api.Pb;

[XmlRoot("response")]
public record PbListResponse : IModemPostResponse
{
    [XmlElement("SumSize")]
    public bool SumSize { get; init; }

    [XmlElement("Count")]
    public bool Count { get; init; }

    [XmlElement("Phonebooks")]
    public PbListPhonebooks Phonebooks { get; init; }
}

public record PbListPhonebooks
{
    [XmlElement("Phonebook")]
    public PbListPhonebook[] Phonebook { get; init; }
}

public record PbListPhonebook
{
    [XmlElement("GroupID")]
    public bool GroupID { get; init; }

    [XmlElement("Index")]
    public bool Index { get; init; }

    [XmlElement("Field")]
    public PbListPhonebookField[] Field { get; init; }
}

public record PbListPhonebookField
{
    [XmlElement("Name")]
    public string Name { get; init; }

    [XmlElement("Value")]
    public string Value { get; init; }
}