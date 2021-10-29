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

    public async ValueTask<Clock?> GetClockAsync(Guid id)
    {
        var clock = this.Clocks.FirstOrDefault(c => c.Id == id);
        return await ValueTask.FromResult(clock);
    }

    public async ValueTask UpdateClockAsync(Guid id, Clock clock)
    {
        var updateTarget = this.Clocks.FirstOrDefault(c => c.Id == id);
        if (updateTarget == null) return;
        updateTarget.Name = clock.Name;
        updateTarget.TimeZoneId = clock.TimeZoneId;
        
        await ValueTask.CompletedTask;
    }
}
