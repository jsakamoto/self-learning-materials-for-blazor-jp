namespace BlazorWorldClock.Shared;

public class Clock
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = "";

    public string TimeZoneId { get; set; } = "";

    public DateTime GetCurrentTime()
    {
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById(this.TimeZoneId);
        return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
    }
}
