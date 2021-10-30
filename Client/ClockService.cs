using System.Net.Http.Json;
using BlazorWorldClock.Shared;

namespace BlazorWorldClock.Client;

public class ClockService
{
    private HttpClient HttpClient { get; }

    public ClockService(HttpClient httpClient)
    {
        this.HttpClient = httpClient;
    }

    public async ValueTask<IEnumerable<Clock>> GetClocksAsync()
    {
        return await this.HttpClient.GetFromJsonAsync<Clock[]>("api/clocks") ?? Enumerable.Empty<Clock>();
    }

    public async ValueTask AddClockAsync(Clock clock)
    {
        await this.HttpClient.PostAsJsonAsync("api/clocks", clock);
    }

    public async ValueTask<Clock?> GetClockAsync(Guid id)
    {
        return await this.HttpClient.GetFromJsonAsync<Clock>($"api/clocks/{id}");
    }

    public async ValueTask UpdateClockAsync(Guid id, Clock clock)
    {
        await this.HttpClient.PutAsJsonAsync($"api/clocks/{id}", clock);
    }

    public async ValueTask DeleteClockAsync(Guid id)
    {
        await this.HttpClient.DeleteAsync($"api/clocks/{id}");
    }
}
