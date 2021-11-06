using Blazored.LocalStorage;
using BlazorWorldClock.Client;
using BlazorWorldClock.Client.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();
// builder.Services.AddScoped<IClockService, ClockService>();
builder.Services.AddScoped<IClockService, LocalStorageClockService>();

await builder.Build().RunAsync();
