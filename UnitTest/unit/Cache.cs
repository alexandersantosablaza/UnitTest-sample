namespace unit;

internal class Cache(TimeSpan cacheTime)
{
    public record Item(string Url, string Content, DateTime lastCollected);
    private readonly TimeSpan _cacheTime = cacheTime;
    private readonly Dictionary<string, Item> _cache = [];

    public bool Contains(string url)
    {
        return _cache.TryGetValue(url, out var item) switch
        {
            true => DateTime.UtcNow.Subtract(item.lastCollected) < _cacheTime,
            _ => false
        };
    }
    public void Add(Item item) => _cache.Add(item.Url, item);
}
