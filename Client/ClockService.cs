using System.Net.Http.Json;
using BlazorWorldClock.Shared;

namespace BlazorWorldClock.Client;

public class ClockService(HttpClient httpClient) : IClockService
{
    public async ValueTask<IEnumerable<Clock>> GetClocksAsync()
    {
        return await httpClient.GetFromJsonAsync<Clock[]>("api/clocks") ?? [];
    }

    public async ValueTask AddClockAsync(Clock clock)
    {
        await httpClient.PostAsJsonAsync("api/clocks", clock);
    }

    public async ValueTask<Clock?> GetClockAsync(Guid id)
    {
        return await httpClient.GetFromJsonAsync<Clock?>($"api/clocks/{id}");
    }

    public async ValueTask UpdateClockAsync(Clock clock)
    {
        await httpClient.PutAsJsonAsync($"api/clocks/{clock.Id}", clock);
    }

    public async ValueTask DeleteClockAsync(Guid id)
    {
        await httpClient.DeleteAsync($"api/clocks/{id}");
    }
}
