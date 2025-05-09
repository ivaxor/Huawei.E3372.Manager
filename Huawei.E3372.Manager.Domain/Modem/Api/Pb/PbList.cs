using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Pb;

[XmlRoot("response")]
public record PbList : IModemPostResponse
{
    [XmlElement("SumSize")]
    public int SumSize { get; init; }

    [XmlElement("Count")]
    public int Count { get; init; }

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
    public int GroupID { get; init; }

    [XmlElement("Index")]
    public int Index { get; init; }

    [XmlElement("Field")]
    public PbListPhonebookField[] Field { get; init; }
}

public record PbListPhonebookField
{
    [XmlElement("Name")]
    public string? Name { get; init; }

    [XmlElement("Value")]
    public string? Value { get; init; }
}