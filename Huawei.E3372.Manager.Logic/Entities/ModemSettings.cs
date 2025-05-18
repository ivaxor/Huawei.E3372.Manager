using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Huawei.E3372.Manager.Logic.Entities;

public record ModemSettings
{
    public Guid Id { get; set; }

    public Guid ModemId { get; set; }
    public virtual Modem? Modem { get; set; }
    public TimeOnly TokenLifeTime { get; set; }

    public bool PollStatus { get; set; }

    public bool PollSms { get; set; }

    public bool PollIncomingSms { get; set; }
    public bool PollIncomingSmsThenSetAsRead { get; set; }
    public bool PollIncomingSmsThenDelete { get; set; }

    public bool PollOutgoingSms { get; set; }
    public bool PollOutgoingSmsThenDelete { get; set; }

    public bool PollDraftSms { get; set; }
    public bool PollDraftSmsThenDelete { get; set; }
}

public class ModemSettingsEntityTypeConfiguration : IEntityTypeConfiguration<ModemSettings>
{
    public void Configure(EntityTypeBuilder<ModemSettings> builder)
    {
        builder
            .HasOne(s => s.Modem)
            .WithOne(m => m.Settings)
            .HasPrincipalKey<Modem>(m => m.Id)
            .HasForeignKey<ModemSettings>(s => s.ModemId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Property(s => s.TokenLifeTime)
            .HasDefaultValue(TimeOnly.FromTimeSpan(TimeSpan.FromMinutes(3)));

        builder
            .Property(s => s.PollStatus)
            .HasDefaultValue(true);

        builder
            .Property(s => s.PollSms)
            .HasDefaultValue(true);

        builder
            .Property(s => s.PollIncomingSms)
            .HasDefaultValue(true);

        builder
           .Property(s => s.PollOutgoingSms)
           .HasDefaultValue(true);

        builder
           .Property(s => s.PollDraftSms)
           .HasDefaultValue(true);
    }
}