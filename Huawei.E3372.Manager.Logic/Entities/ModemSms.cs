using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

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
    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset LastUpdatedAt { get; set; }

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
        if (CreatedAt != sms.CreatedAt) return false;

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