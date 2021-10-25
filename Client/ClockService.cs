using BlazorWorldClock.Shared;

namespace BlazorWorldClock.Client;

public class ClockService
{
    private List<Clock> Clocks { get; } = new()
    {
        new() { Name = "札幌", TimeZoneId = "Asia/Tokyo" },
        new() { Name = "バンコク", TimeZoneId = "Asia/Bangkok" },
        new() { Name = "シアトル", TimeZoneId = "America/Los_Angeles" },
    };

    public async ValueTask<IEnumerable<Clock>> GetClocksAsync()
    {
        return await ValueTask.FromResult(this.Clocks);
    }

    public async ValueTask AddClockAsync(Clock clock)
    {
        this.Clocks.Add(clock);
        await ValueTask.CompletedTask;
    }
}
