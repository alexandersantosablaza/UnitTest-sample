namespace UnitTest.src.Tests;

using System.Net.NetworkInformation;
using Xunit;
public class NetworkUtilityServiceTests
{
    public NetworkUtilityServiceTests()
    {
        _pingsvc = new NetworkService();
    }
    private readonly NetworkService _pingsvc;
    [Fact]
    public void NetworkService_SendPing_ReturnsString()
    {
        //arrange
        //act
        string res = _pingsvc.SendPing();
        //assert
        Assert.Equal("Ping sent!", res);
        Assert.IsNotAssignableFrom(typeof(Nullable), res);
        Assert.IsAssignableFrom<object>(res);
        Assert.NotNull(res);
    }
    [Theory]
    [InlineData(2,1,3)]
    public void NetworkService_PingTimeout_ReturnsInt(
        int a,
        int b,
        int exp)
    {
        // arrange
        // act
        int res = _pingsvc.PingTimeout(a, b);
        // assert
        Assert.Equal(exp, res);
        Assert.IsType<Int32>(res);
        Assert.IsNotAssignableFrom(typeof(Nullable), res);
        Assert.NotInRange(res, -1000, 0);
      
    }
    [Fact]
    public void NetworkService_LastPingDate_ReturnsDateTime()
    {
        // arrange
        // act
        var res = _pingsvc.LastPingDate();
        // assert
        Assert.IsType<DateTime>(res);
        Assert.IsNotAssignableFrom(typeof(Nullable), res);
        Assert.InRange(res, DateTime.MinValue, DateTime.MaxValue);
    }
    [Fact]
    public void NetworkService_GetPingOptions_ReturnsObject()
    {
        var res = _pingsvc.GetOptionsForPing();
        Assert.IsAssignableFrom<object>(res);
        Assert.IsAssignableFrom<PingOptions>(res);
        Assert.True(res?.DontFragment);
    }
    [Fact]
    public void NetworkService_MostRecentPings_ReturnsCollection()
    {
        var res = _pingsvc.MostRecentPing();
        var expected = new PingOptions()
        {
            DontFragment = true,
            Ttl = 1
        };
        Assert.IsAssignableFrom<object>(res);
        Assert.NotNull(res);
        Assert.IsAssignableFrom<IEnumerable<PingOptions>>(res);
        foreach(var x in res)
        {
            Assert.True(x.DontFragment);
            Assert.Equal(1,x.Ttl);
        }
        Assert.Equal(3, res.Count());

    }
}
