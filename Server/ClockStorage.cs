using System.Text.Json;
using BlazorWorldClock.Shared;

namespace BlazorWorldClock.Server;

public class ClockStorage
{
    private string StoragePath { get; }

    private List<Clock> Clocks { get; } = new();

    public ClockStorage(string storagePath)
    {
        this.StoragePath = storagePath;
        if (!File.Exists(this.StoragePath)) return;

        var json = File.ReadAllText(this.StoragePath);
        this.Clocks.AddRange(JsonSerializer.Deserialize<Clock[]>(json) ?? Enumerable.Empty<Clock>());
    }

    public void AddClock(Clock Clock)
    {
        lock (this)
        {
            this.Clocks.Add(Clock);
            this.FlushToStorage();
        }
    }

    public List<Clock> GetClocks()
    {
        lock (this) return this.Clocks;
    }

    public Clock GetClock(Guid id)
    {
        lock (this) return this.Clocks.Find(c => c.Id == id) ?? throw new Exception($"The clock was not found.");
    }

    public void UpdateClock(Guid id, Clock Clock)
    {
        lock (this)
        {
            var updateTo = this.GetClock(id);
            updateTo.Name = Clock.Name;
            updateTo.TimeZoneId = Clock.TimeZoneId;
            this.FlushToStorage();
        }
    }

    public void DeleteClock(Guid id)
    {
        lock (this)
        {
            var clock = this.GetClock(id);
            this.Clocks.Remove(clock);
            this.FlushToStorage();
        }
    }

    private void FlushToStorage()
    {
        var baseDir = Path.GetDirectoryName(this.StoragePath) ?? ".";
        if (!Directory.Exists(baseDir)) Directory.CreateDirectory(baseDir);

        var json = JsonSerializer.Serialize(this.Clocks);
        File.WriteAllTextAsync(this.StoragePath, json);
    }
}

