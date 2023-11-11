using BlazorWorldClock.Shared;

namespace BlazorWorldClock.Client;

public class ClockService
{
    private readonly List<Clock> _clocks = [
        new() { Name = "札幌", TimeZoneId = "Asia/Tokyo" },
        new() { Name = "バンコク", TimeZoneId = "Asia/Bangkok" },
        new() { Name = "シアトル", TimeZoneId = "America/Los_Angeles" }
    ];

    public IEnumerable<Clock> GetClocks() => _clocks;
}
