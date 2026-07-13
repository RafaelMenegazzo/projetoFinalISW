using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using projetoFinalISW.Components;
using projetoFinalISW.Components.Data;
using projetoFinalISW.Components.Services;
using Amazon;
using Amazon.Extensions.NETCore.Setup;
using Amazon.S3;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("PostgresConnection")));

builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<LivroService>();
builder.Services.AddScoped<AluguelService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddAWSService<IAmazonS3>();
builder.Services.AddScoped<S3Service>();

string regiaoAws =
    builder.Configuration["AWS:Region"] ?? "us-east-1";

builder.Services.AddSingleton<IAmazonS3>(_ =>
    new AmazonS3Client(
        RegionEndpoint.GetBySystemName(regiaoAws)));

builder.Services.AddDefaultAWSOptions(
    builder.Configuration.GetAWSOptions());

builder.Services.AddAWSService<IAmazonS3>();

builder.Services.AddScoped<S3Service>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    db.Database.Migrate();
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
