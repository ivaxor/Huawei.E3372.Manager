using System.Xml.Serialization;

namespace Huawei.E3372.Manager.Domain.Modem.Api.Pb;

[XmlRoot("response")]
public record PbListResponse : IModemPostResponse
{
    [XmlElement("SumSize")]
    public required int SumSize { get; init; }

    [XmlElement("Count")]
    public required int Count { get; init; }

    [XmlElement("Phonebooks")]
    public required PbListPhonebooks Phonebooks { get; init; }
}

public record PbListPhonebooks
{
    [XmlElement("Phonebook")]
    public required PbListPhonebook[] Phonebook { get; init; }
}

public record PbListPhonebook
{
    [XmlElement("GroupID")]
    public required int GroupID { get; init; }

    [XmlElement("Index")]
    public required int Index { get; init; }

    [XmlElement("Field")]
    public required PbListPhonebookField[] Field { get; init; }
}

public record PbListPhonebookField
{
    [XmlElement("Name")]
    public required string Name { get; init; }

    [XmlElement("Value")]
    public required string Value { get; init; }
}