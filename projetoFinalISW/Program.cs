using Amazon.Extensions.NETCore.Setup;
using Amazon.S3;
using Microsoft.EntityFrameworkCore;
using projetoFinalISW.Components;
using projetoFinalISW.Components.Data;
using projetoFinalISW.Components.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString(
            "PostgresConnection")));

builder.Services.AddDefaultAWSOptions(
    builder.Configuration.GetAWSOptions());

builder.Services.AddAWSService<IAmazonS3>();

builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<LivroService>();
builder.Services.AddScoped<AluguelService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<S3Service>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider
        .GetRequiredService<AppDbContext>();

    db.Database.Migrate();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(
        "/Error",
        createScopeForErrors: true);

    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute(
    "/not-found",
    createScopeForStatusCodePages: true);

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();