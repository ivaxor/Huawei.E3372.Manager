using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Huawei.E3372.Manager.Logic.Entities;

public record Modem
{
    public Guid Id { get; set; }

    public Uri Uri { get; set; }
    public string DeviceName { get; set; }
    public string SerialNumber { get; set; }
    public string IMEI { get; set; }

    public string MacAddress { get; set; }

    public virtual ModemSettings? Settings { get; set; }
    public virtual ModemStatus? Status { get; set; }
    public virtual IEnumerable<ModemSms>? Sms { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset LastUpdatedAt { get; set; }

    public virtual bool Equals(Modem modem)
    {
        if (modem == null) return false;

        if (Uri != modem.Uri) return false;

        if (DeviceName != modem.DeviceName) return false;

        if (SerialNumber != modem.SerialNumber) return false;
        if (IMEI != modem.IMEI) return false;
        if (MacAddress != modem.MacAddress) return false;

        return true;
    }
}

public class ModemEntityTypeConfiguration : IEntityTypeConfiguration<Modem>
{
    public void Configure(EntityTypeBuilder<Modem> builder)
    {
        builder
            .HasIndex(m => m.Uri)
            .IsUnique();
    }
}