using System.Net.NetworkInformation;

namespace UnitTest.src;
internal class NetworkService
{
    public static void Main(string[] args)
    {
        NetworkService service = new();
        service.SendPing().Print();
        
    }
    internal string SendPing() => "Ping sent!";
    internal int PingTimeout(int a, int b) => a + b;
    internal DateTime LastPingDate() => DateTime.Now;
    internal PingOptions GetOptionsForPing() => new PingOptions()
    {
        DontFragment = true,
        Ttl = 1
    };
    internal IEnumerable<PingOptions> MostRecentPing() => [
        new PingOptions
        {
            DontFragment = true,
            Ttl = 1
        },new PingOptions
        {
            DontFragment = true,
            Ttl = 1
        },new PingOptions
        {
            DontFragment = true,
            Ttl = 1
        },
    ];
}
public static class Extension
{
    public static void Print(this string self)
    {
        Console.WriteLine(self);
    }
}