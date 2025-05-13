using Huawei.E3372.Manager.Logic.Modems.Models.Api.Sms;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Web;

namespace Huawei.E3372.Manager.Logic.Entities;

public record ModemSms
{
    public Guid Id { get; set; }

    public Guid ModemId { get; set; }
    public virtual Modem? Modem { get; set; }

    public int Index { get; set; }

    public ModemSmsStatus Status { get; set; }
    public string? FromPhoneNumber { get; set; }
    public string? ToPhoneNumbers { get; set; }
    public string Content { get; set; }
    public int Priority { get; set; }
    public DateTime DateTime { get; set; }

    public DateTime LastUpdatedAt { get; set; }

    public ModemSms() { }
    public ModemSms(Modem modem, SmsListMessage sms)
    {
        ModemId = modem.Id;

        Index = sms.Index;

        Status = sms.Status switch
        {
            0 => ModemSmsStatus.Unread,
            1 => ModemSmsStatus.Read,
            2 => ModemSmsStatus.Failed,
            3 => ModemSmsStatus.Delivered,
            _ => throw new NotImplementedException(),
        };

        FromPhoneNumber = Status switch
        {
            ModemSmsStatus.Unread => sms.Phones,
            ModemSmsStatus.Read => sms.Phones,
            ModemSmsStatus.Failed => modem.Status?.PhoneNumber,
            ModemSmsStatus.Delivered => modem.Status?.PhoneNumber,
            _ => throw new NotImplementedException(),
        };

        ToPhoneNumbers = Status switch
        {
            ModemSmsStatus.Unread => modem.Status?.PhoneNumber,
            ModemSmsStatus.Read => modem.Status?.PhoneNumber,
            ModemSmsStatus.Failed => sms.Phones,
            ModemSmsStatus.Delivered => sms.Phones,
            _ => throw new NotImplementedException(),
        };

        Content = HttpUtility.HtmlDecode(sms.Content);
        Priority = sms.Priority;
        DateTime = DateTime.Parse(sms.Date);
        
    }

    public virtual bool Equals(ModemSms sms)
    {
        if (sms == null) return false;

        if (ModemId != sms.ModemId) return false;

        if (Index != sms.Index) return false;
        if (Status != sms.Status) return false;
        if (FromPhoneNumber != sms.FromPhoneNumber) return false;
        if (ToPhoneNumbers != sms.ToPhoneNumbers) return false;
        if (Content != sms.Content) return false;
        if (Priority != sms.Priority) return false;
        if (DateTime != sms.DateTime) return false;

        return true;
    }
}

public enum ModemSmsStatus
{
    Unread,
    Read,
    Failed,
    Delivered,
}

public enum ModemSmsType
{
    Outgoing,
    Incoming,
}

public class ModemSmsEntityTypeConfiguration : IEntityTypeConfiguration<ModemSms>
{
    public void Configure(EntityTypeBuilder<ModemSms> builder)
    {
        builder
            .HasOne(s => s.Modem)
            .WithMany(m => m.Sms)
            .HasPrincipalKey(m => m.Id)
            .HasForeignKey(s => s.ModemId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasIndex(s => new { s.ModemId, s.Index })
            .IsUnique();

        builder
            .Property(s => s.FromPhoneNumber)
            .IsRequired(false);

        builder
            .Property(s => s.ToPhoneNumbers)
            .IsRequired(false);
    }
}