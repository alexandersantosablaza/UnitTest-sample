namespace unit;

public class CacheTests
{
    private const string URL = "url"
                  , NOT_FOUND = "something"
                  , CONTENT = "content";
    private readonly Cache _cache = new(TimeSpan.FromDays(1));
    [Fact]
    public void CacheItemWithinTimeSpan()
    {
        _cache.Add(new(URL, CONTENT, DateTime.Now));
        bool contains = _cache.Contains(URL)
             , notExist = _cache.Contains(NOT_FOUND);
        Assert.True(contains);
        Assert.False(notExist);
    }
    [Fact]
    public void BustItemOutsideTimeSpan()
    {
        _cache.Add(new(URL, CONTENT, DateTime.Now.AddDays(-2)));
        bool contains = _cache.Contains(URL);
    }
}
