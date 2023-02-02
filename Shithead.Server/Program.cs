using Blazored.LocalStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shithead.Shared.Services;
using Microsoft.AspNetCore.ResponseCompression;
using System.Linq;
using Shithead.Server.Hubs;
using Shithead.Shared.Models;

/// <summary>
/// Web application builder
/// </summary>
var builder = WebApplication.CreateBuilder(args);

/// <summary>
/// Services
/// </summary>
var services = builder.Services;

// Add services to the container.
services.AddControllersWithViews();
services.AddRazorPages();

// Service declaration 
services.AddScoped<IRequestService, RequestService>();
services.AddScoped<IUserApiService, UserApiService>();
services.AddScoped<ILocalStorageService, LocalStorageService>();
services.AddScoped<IImageInputServices, ImageInputServices>();
services.AddScoped<IGameApiService, GameApiService>();
services.AddScoped<INotificationApiService, NotificationApiService>();

// SignalR
// Signalr service
services.AddSignalR(option => {
    option.EnableDetailedErrors = true; // TODO: remove on production
    option.MaximumReceiveMessageSize = 100 * 1024 * 1024; // 100MB max SingalR receive data size.
});

builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});



var app = builder.Build();
app.UseResponseCompression();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseStatusCodePages();
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapHub<GameHub>("/gamehub");
app.MapFallbackToPage("/_Host");

app.Run();