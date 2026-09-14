using System.Text.Json;
using BlazorWorldClock.Shared;
using Microsoft.JSInterop;

namespace BlazorWorldClock.Client;

public class LocalStorageClockService : IClockService
{
    private readonly IJSRuntime _js;

    private const string LocalStorageKey = "clocks";

    public LocalStorageClockService(IJSRuntime localStorage)
    {
        _js = localStorage;
    }

    public async ValueTask<IEnumerable<Clock>> GetClocksAsync()
    {
        var clocksJson = await _js.InvokeAsync<string>("localStorage.getItem", LocalStorageKey) ?? "[]";
        return JsonSerializer.Deserialize<Clock[]>(clocksJson) ?? [];
    }

    public async ValueTask AddClockAsync(Clock clock)
    {
        var clocks = await this.GetClocksAsync();
        clocks = clocks.Append(clock);
        await _js.InvokeVoidAsync("localStorage.setItem", LocalStorageKey, JsonSerializer.Serialize(clocks));
    }

    public async ValueTask DeleteClockAsync(Guid id)
    {
        var clocks = await this.GetClocksAsync();
        clocks = clocks.Where(c => c.Id != id);
        await _js.InvokeVoidAsync("localStorage.setItem", LocalStorageKey, JsonSerializer.Serialize(clocks));
    }

    public async ValueTask<Clock?> GetClockAsync(Guid id)
    {
        var clocks = await this.GetClocksAsync();
        return clocks.FirstOrDefault(c => c.Id == id);
    }

    public async ValueTask UpdateClockAsync(Clock clock)
    {
        var clocks = await this.GetClocksAsync();
        var updateTo = clocks.FirstOrDefault(c => c.Id == clock.Id) ?? throw new Exception($"The clock was not found.");
        updateTo.Name = clock.Name;
        updateTo.TimeZoneId = clock.TimeZoneId;

        await _js.InvokeVoidAsync("localStorage.setItem", LocalStorageKey, JsonSerializer.Serialize(clocks));
    }
}
