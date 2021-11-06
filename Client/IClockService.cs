using BlazorWorldClock.Shared;

namespace BlazorWorldClock.Client;

public interface IClockService
{
    ValueTask<IEnumerable<Clock>> GetClocksAsync();
    ValueTask AddClockAsync(Clock clock);
    ValueTask<Clock?> GetClockAsync(Guid id);
    ValueTask UpdateClockAsync(Clock clock);
    ValueTask DeleteClockAsync(Guid id);
}
