using Huawei.E3372.Manager.Runtime.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddControllers();
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
    app.UseExceptionHandler("/Error", createScopeForErrors: true);

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

app.Run();