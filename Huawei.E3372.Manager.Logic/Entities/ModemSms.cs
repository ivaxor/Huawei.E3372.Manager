using Huawei.E3372.Manager.Logic.Modems.Models.Api.Sms;

namespace Huawei.E3372.Manager.Logic.Entities;

public record ModemSms
{
    public Guid Id { get; init; }
    public Guid ModemId { get; init; }
    public int Index { get; init; }
    public ModemSmsType Type { get; init; }
    public string PhoneNumber { get; init; }
    public string Content { get; init; }
    public int Priority { get; init; }
    public DateTime DateTime { get; init; }
    public ModemSmsStatus Status { get; init; }
    public DateTime LastUpdatedAt { get; init; }

    public ModemSms() { }
    public ModemSms(Modem modem, SmsListMessage sms)
    {
        Id = Guid.NewGuid();
        ModemId = modem.Id;

        Index = sms.Index;
        Type = sms.Type switch
        {
            1 => ModemSmsType.Outgoing,
            2 => ModemSmsType.Incoming,
            _ => throw new NotImplementedException(),
        };
        PhoneNumber = sms.Phone;
        Content = sms.Content;
        Priority = sms.Priority;
        DateTime = DateTime.Parse(sms.Date);
        Status = sms.Status switch
        {
            0 => ModemSmsStatus.Unread,
            1 => ModemSmsStatus.Read,
            3 => ModemSmsStatus.Sent,
            _ => throw new NotImplementedException(),
        };
    }

    public virtual bool Equals(ModemSms sms)
    {
        if (ModemId != sms.ModemId) return false;
        if (Index != sms.Index) return false;
        if (Type != sms.Type) return false;
        if (PhoneNumber != sms.PhoneNumber) return false;
        if (Content != sms.Content) return false;
        if (Priority != sms.Priority) return false;
        if (DateTime != sms.DateTime) return false;
        if (Status != sms.Status) return false;
        if (Status != sms.Status) return false;

        return true;
    }
}

public enum ModemSmsStatus
{
    Unread,
    Read,
    Sent,
}


public enum ModemSmsType
{
    Outgoing,
    Incoming,
}