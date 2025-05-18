using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Huawei.E3372.Manager.Logic.Entities;

public record ModemSettings
{
    public Guid Id { get; set; }

    #region Modem
    public Guid ModemId { get; set; }
    public virtual Modem? Modem { get; set; }
    public TimeOnly ModemTokenLifeTime { get; set; }
    #endregion

    #region Status
    public bool PollStatus { get; set; }
    public TimeOnly PollStatusInterval { get; set; }
    #endregion

    #region SMS
    public bool PollSms { get; set; }
    public TimeOnly PollSmsInterval { get; set; }

    public bool PollIncomingSms { get; set; }
    public bool PollIncomingSmsThenSetAsRead { get; set; }
    public bool PollIncomingSmsThenDelete { get; set; }

    public bool PollOutgoingSms { get; set; }
    public bool PollOutgoingSmsThenDelete { get; set; }

    public bool PollDraftSms { get; set; }
    public bool PollDraftSmsThenDelete { get; set; }
    #endregion
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
            .Property(s => s.ModemTokenLifeTime)
            .HasDefaultValue(TimeOnly.FromTimeSpan(TimeSpan.FromMinutes(3)));


        builder
            .Property(s => s.PollStatus)
            .HasDefaultValue(true);

        builder
            .Property(s => s.PollStatusInterval)
            .HasDefaultValue(TimeOnly.FromTimeSpan(TimeSpan.FromMinutes(5)));

        builder
            .Property(s => s.PollSms)
            .HasDefaultValue(true);

        builder
            .Property(s => s.PollSmsInterval)
            .HasDefaultValue(TimeOnly.FromTimeSpan(TimeSpan.FromMinutes(1)));

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