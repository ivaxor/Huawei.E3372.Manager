using Huawei.E3372.Manager.Logic.Entities;
using Microsoft.EntityFrameworkCore;

namespace Huawei.E3372.Manager.Logic;

public class ApplicationDbContext : DbContext
{
    public DbSet<Modem> Modems { get; set; }
    public DbSet<ModemSms> ModemSms { get; set; }
    public DbSet<ModemStatus> ModemStatuses { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var databaseFilePath = Path.Combine(Environment.ProcessPath!, "data", "HuaweiE3372Manager.sqlite3");
        options.UseSqlite($"Data Source={databaseFilePath}");
    }
}