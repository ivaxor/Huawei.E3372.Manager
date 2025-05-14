using Huawei.E3372.Manager.Logic.Entities;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
namespace Huawei.E3372.Manager.Logic;

public class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options)
    : DbContext(options), IDataProtectionKeyContext
{
    public DbSet<Modem> Modems { get; set; }
    public DbSet<ModemSms> ModemSms { get; set; }
    public DbSet<ModemStatus> ModemStatuses { get; set; }

    public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<DateTime>()
            .HaveConversion<DateTimeToUniversalTimeConverter>();

        base.ConfigureConventions(configurationBuilder);
    }

    internal class DateTimeToUniversalTimeConverter : ValueConverter<DateTime, DateTime>
    {
        public DateTimeToUniversalTimeConverter() : base(x => x.ToUniversalTime(), x => x.ToUniversalTime()) { }
    }
}