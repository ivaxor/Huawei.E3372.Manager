using Huawei.E3372.Manager.Logic.Modems.Models;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.Device;
using Huawei.E3372.Manager.Logic.Modems.Models.Api.Monitoring;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Web;

namespace Huawei.E3372.Manager.Logic.Entities;

public record ModemStatus
{
    public Guid Id { get; set; }

    public Guid ModemId { get; set; }
    public virtual Modem? Modem { get; set; }

    public string? IMSI { get; set; }
    public string? ICCID { get; set; }

    public string? OperatorName { get; set; }
    public string? OperatorNumber { get; set; }
    public string? PhoneNumber { get; set; }

    public int? CellId { get; set; }
    public string? RSRQ { get; set; }
    public string? RSRP { get; set; }
    public string? RSSI { get; set; }
    public string? SINR { get; set; }

    public bool SmsStorageFull { get; set; }

    public DateTime LastUpdatedAt { get; set; }

    public ModemStatus() { }
    public ModemStatus(
        Modem modem,
        InformationResponse information,
        OperatorResponse operatorInfo,
        SignalResponse signal,
        CheckNotificationResponse checkNotification)
    {
        ModemId = modem.Id;

        IMSI = information.Imsi;
        ICCID = information.Iccid;

        OperatorName = HttpUtility.HtmlDecode(operatorInfo.FullName);
        OperatorNumber = operatorInfo.Numeric;

        CellId = signal.CellId;
        RSRQ = HttpUtility.HtmlDecode(signal.Rsrq);
        RSRP = HttpUtility.HtmlDecode(signal.Rsrp);
        RSSI = HttpUtility.HtmlDecode(signal.Rssi);
        SINR = HttpUtility.HtmlDecode(signal.Sinr);

        SmsStorageFull = checkNotification.SmsStorageFull;

        LastUpdatedAt = DateTime.UtcNow;
    }

    public virtual bool Equals(ModemStatus status)
    {
        if (status == null) return false;

        if (ModemId == status.ModemId) return false;

        if (IMSI == status.IMSI) return false;
        if (ICCID == status.ICCID) return false;

        if (OperatorName == status.OperatorName) return false;
        if (OperatorNumber == status.OperatorNumber) return false;

        if (CellId == status.CellId) return false;
        if (RSRQ == status.RSRQ) return false;
        if (RSRP == status.RSRP) return false;
        if (RSSI == status.RSSI) return false;
        if (SINR == status.SINR) return false;

        if (SmsStorageFull == status.SmsStorageFull) return false;

        return true;
    }
}

public class ModemStatusEntityTypeConfiguration : IEntityTypeConfiguration<ModemStatus>
{
    public void Configure(EntityTypeBuilder<ModemStatus> builder)
    {
        builder
            .HasOne(s => s.Modem)
            .WithOne(m => m.Status)
            .HasPrincipalKey<Modem>(m => m.Id)
            .HasForeignKey<ModemStatus>(s => s.ModemId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Property(s => s.IMSI)
            .IsRequired(false);

        builder
            .Property(s => s.ICCID)
            .IsRequired(false);

        builder
            .Property(s => s.OperatorName)
            .IsRequired(false);

        builder
            .Property(s => s.OperatorNumber)
            .IsRequired(false);

        builder
            .Property(s => s.PhoneNumber)
            .IsRequired(false);

        builder
            .Property(s => s.CellId)
            .IsRequired(false);

        builder
            .Property(s => s.RSRQ)
            .IsRequired(false);

        builder
            .Property(s => s.RSRP)
            .IsRequired(false);

        builder
            .Property(s => s.RSRQ)
            .IsRequired(false);

        builder
            .Property(s => s.RSSI)
            .IsRequired(false);

        builder
            .Property(s => s.SINR)
            .IsRequired(false);
    }
}