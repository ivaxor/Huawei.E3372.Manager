using Huawei.E3372.Manager.Logic;
using Huawei.E3372.Manager.Logic.Modems;
using Huawei.E3372.Manager.Runtime.Components;
using Huawei.E3372.Manager.Worker;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddControllers();
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

builder.Services.AddMemoryCache();

builder.Services
    .AddDbContext<ApplicationDbContext>(options =>
    {
        var sqliteConnectionString = builder.Configuration.GetConnectionString(nameof(SqliteConnection));
        if (!string.IsNullOrEmpty(sqliteConnectionString))
            options.UseSqlite(sqliteConnectionString);
    });

builder.Services.AddHostedService<SmsPollBackgroundService>();

builder.Services.AddHttpClient();
builder.Services.AddSingleton<IModemClient, ModemClient>();
builder.Services.AddTransient<IDiscoveryService, DiscoveryService>();
builder.Services.AddTransient<IStatusService, StatusService>();
builder.Services.AddTransient<ISmsService, SmsService>();

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

using var serviceScope = app.Services.GetService<IServiceScopeFactory>()!.CreateScope();
using var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
await dbContext.Database.EnsureCreatedAsync();

app.Run();