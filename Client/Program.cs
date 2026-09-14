using BlazorWorldClock.Client;
using BlazorWorldClock.Client.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

#if USE_LOCAL_STORAGE
builder.Services.AddScoped<IClockService, LocalStorageClockService>();
#else
builder.Services.AddScoped<IClockService, ClockService>();
#endif

await builder.Build().RunAsync();
