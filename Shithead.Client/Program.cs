using System;
using System.Net.Http;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Shithead.Shared.Services;

/// <summary>
/// Web application builder
/// </summary>
var builder = WebAssemblyHostBuilder.CreateDefault(args);

/// <summary>
/// Services
/// </summary>
var services = builder.Services;

//builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Service declaration 
services.AddScoped<IRequestService, RequestService>();
services.AddScoped<IUserApiService, UserApiService>();
services.AddScoped<ILocalStorageService, LocalStorageService>();
services.AddScoped<IImageInputServices, ImageInputServices>();
services.AddScoped<IGameApiService, GameApiService>();
services.AddScoped<INotificationApiService, NotificationApiService>();

await builder.Build().RunAsync();