using Huawei.E3372.Manager.Logic;
using Huawei.E3372.Manager.Logic.Entities;
using Huawei.E3372.Manager.Logic.Modems;
using Huawei.E3372.Manager.Runtime.Components;
using Huawei.E3372.Manager.Runtime.Workers;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ApplicationSettings>(builder.Configuration.GetSection(nameof(ApplicationSettings)));

builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddControllers();
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var sqliteConnectionString = builder.Configuration.GetConnectionString(nameof(SqliteConnection));
    if (!string.IsNullOrEmpty(sqliteConnectionString))
        options.UseSqlite(sqliteConnectionString);

    var sqlServerConnectionString = builder.Configuration.GetConnectionString(nameof(SqlServerConnection));
    if (!string.IsNullOrEmpty(sqlServerConnectionString))
        options.UseSqlServer(sqlServerConnectionString);

    var npgsqlConnectionString = builder.Configuration.GetConnectionString(nameof(NpgsqlConnection));
    if (!string.IsNullOrEmpty(npgsqlConnectionString))
        options.UseNpgsql(npgsqlConnectionString);
});

builder.Services
    .AddDataProtection()
    .PersistKeysToDbContext<ApplicationDbContext>();

builder.Services
    .AddHealthChecks()
    .AddDbContextCheck<ApplicationDbContext>();

builder.Services.AddMemoryCache();
builder.Services.AddHttpClient();

builder.Services.AddHostedService<SmsPollBackgroundService>();
builder.Services.AddHostedService<StatusPollBackgroundService>();

builder.Services.AddSingleton<IModemClient, ModemClient>();
builder.Services.AddScoped<IDiscoveryService, DiscoveryService>();
builder.Services.AddScoped<IStatusService, StatusService>();
builder.Services.AddScoped<ISmsService, SmsService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseHsts();
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();
app.UseAntiforgery();

app
    .MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapControllers();
app
    .UseSwagger()
    .UseSwaggerUI();

app.MapHealthChecks("/healthz");

using var dbContext = app.Services.GetService<IServiceScopeFactory>()!.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
await dbContext.Database.EnsureCreatedAsync();

app.Run();