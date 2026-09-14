using BlazorWorldClock.Shared;

namespace BlazorWorldClock.Client;

public class ClockService
{
    private readonly List<Clock> _clocks = [
        new() { Name = "札幌", TimeZoneId = "Asia/Tokyo" },
        new() { Name = "バンコク", TimeZoneId = "Asia/Bangkok" },
        new() { Name = "シアトル", TimeZoneId = "America/Los_Angeles" }
    ];

    public async ValueTask<IEnumerable<Clock>> GetClocksAsync()
    {
        return await ValueTask.FromResult(_clocks);
    }

    public async ValueTask AddClockAsync(Clock clock)
    {
        _clocks.Add(clock);
        await ValueTask.CompletedTask;
    }

    public async ValueTask<Clock?> GetClockAsync(Guid id)
    {
        return await ValueTask.FromResult(_clocks.FirstOrDefault(c => c.Id == id));
    }

    public async ValueTask UpdateClockAsync(Clock clock)
    {
        var index = _clocks.FindIndex(c => c.Id == clock.Id);
        if (index >= 0)
        {
            _clocks[index] = clock;
        }
        await ValueTask.CompletedTask;
    }
}
