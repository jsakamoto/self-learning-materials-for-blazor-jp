using System.Text.Json;
using BlazorWorldClock.Shared;

namespace BlazorWorldClock.Server;

public class ClockStorage
{
    private readonly string _storagePath;

    private readonly List<Clock> _clocks = [];

    public ClockStorage(string storagePath)
    {
        _storagePath = storagePath;
        if (!File.Exists(_storagePath)) return;

        var json = File.ReadAllText(_storagePath);
        _clocks.AddRange(JsonSerializer.Deserialize<Clock[]>(json) ?? []);
    }

    public void AddClock(Clock clock)
    {
        lock (this)
        {
            _clocks.Add(clock);
            this.FlushToStorage();
        }
    }

    public List<Clock> GetClocks()
    {
        lock (this) return _clocks;
    }

    public Clock GetClock(Guid id)
    {
        lock (this) return _clocks.Find(c => c.Id == id) ?? throw new Exception($"The clock was not found.");
    }

    public void UpdateClock(Guid id, Clock clock)
    {
        lock (this)
        {
            var index = _clocks.FindIndex(c => c.Id == id);
            if (index < 0) throw new Exception($"The clock was not found.");
            _clocks[index] = clock;
            this.FlushToStorage();
        }
    }

    public void DeleteClock(Guid id)
    {
        lock (this)
        {
            var clock = this.GetClock(id);
            _clocks.Remove(clock);
            this.FlushToStorage();
        }
    }

    private void FlushToStorage()
    {
        var baseDir = Path.GetDirectoryName(_storagePath) ?? ".";
        if (!Directory.Exists(baseDir)) Directory.CreateDirectory(baseDir);

        var json = JsonSerializer.Serialize(_clocks);
        File.WriteAllTextAsync(_storagePath, json);
    }
}
