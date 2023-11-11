using BlazorWorldClock.Server;
using BlazorWorldClock.Shared;
using static System.Environment.SpecialFolder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

var storagePath = Path.Combine(Environment.GetFolderPath(ApplicationData), "Blazor World Clock", "clocks.json");
var clockStorage = new ClockStorage(storagePath);

app.MapPost("/api/clocks", (Clock clock) => clockStorage.AddClock(clock));
app.MapGet("/api/clocks", () => clockStorage.GetClocks());
app.MapGet("/api/clocks/{id}", (Guid id) => clockStorage.GetClock(id));
app.MapPut("/api/clocks/{id}", (Guid id, Clock clock) => clockStorage.UpdateClock(id, clock));
app.MapDelete("/api/clocks/{id}", (Guid id) => clockStorage.DeleteClock(id));

app.UseRouting();
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
