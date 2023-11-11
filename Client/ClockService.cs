using System.Net.Http.Json;
using BlazorWorldClock.Shared;

namespace BlazorWorldClock.Client;

public class ClockService
{
    private readonly HttpClient _httpClient;

    public ClockService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async ValueTask<IEnumerable<Clock>> GetClocksAsync()
    {
        return await _httpClient.GetFromJsonAsync<Clock[]>("api/clocks") ?? [];
    }

    public async ValueTask AddClockAsync(Clock clock)
    {
        await _httpClient.PostAsJsonAsync("api/clocks", clock);
    }

    public async ValueTask<Clock?> GetClockAsync(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<Clock?>($"api/clocks/{id}");
    }

    public async ValueTask UpdateClockAsync(Clock clock)
    {
        await _httpClient.PutAsJsonAsync($"api/clocks/{clock.Id}", clock);
    }

    public async ValueTask DeleteClockAsync(Guid id)
    {
        await _httpClient.DeleteAsync($"api/clocks/{id}");
    }
}
