using System.ComponentModel.DataAnnotations;

namespace BlazorWorldClock.Shared;

public class Clock
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "表示名を入力してください。")]
    [StringLength(20, ErrorMessage = "表示名は20文字までです。")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "タイムゾーンを選択してください。")]
    public string TimeZoneId { get; set; } = "";

    public DateTime GetCurrentTime()
    {
        var timeZone = TimeZoneInfo.FindSystemTimeZoneById(this.TimeZoneId);
        return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
    }
}
