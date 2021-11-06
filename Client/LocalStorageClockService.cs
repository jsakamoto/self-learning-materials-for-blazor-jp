using Blazored.LocalStorage;
using BlazorWorldClock.Shared;

namespace BlazorWorldClock.Client;

public class LocalStorageClockService : IClockService
{
    private readonly ILocalStorageService _localStorage;

    private const string LocalStorageKey = "clocks";

    public LocalStorageClockService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async ValueTask<IEnumerable<Clock>> GetClocksAsync()
    {
        return await _localStorage.GetItemAsync<Clock[]>(LocalStorageKey) ?? Enumerable.Empty<Clock>();
    }

    public async ValueTask AddClockAsync(Clock clock)
    {
        var clocks = await this.GetClocksAsync();
        clocks = clocks.Append(clock);
        await _localStorage.SetItemAsync(LocalStorageKey, clocks);
    }

    public async ValueTask DeleteClockAsync(Guid id)
    {
        var clocks = await this.GetClocksAsync();
        clocks = clocks.Where(c => c.Id != id);
        await _localStorage.SetItemAsync(LocalStorageKey, clocks);
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

        await _localStorage.SetItemAsync(LocalStorageKey, clocks);
    }
}
