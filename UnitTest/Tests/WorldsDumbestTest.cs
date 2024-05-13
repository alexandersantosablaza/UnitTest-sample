namespace UnitTest;
public class WorldsDumbestTest
{
    public static void WorldsDumbestTest_returnsPikachuIfero_ReturnsString()
    {
        try
        {
            //arrange
            WorldsDumbestFunction f = new();
            const int PIKAChu = 0;
            //act
            string result = f.ReturnsPikachuIfZero(PIKAChu);
            //assert
            switch(result)
            {
                case "PIKACHU":
                   Console.WriteLine("PASSED: PIKACHU!!");
                    break;
                default:
                    Console.WriteLine("FAILED: SQUIRTY");
                    break;
            }
        }
        catch(Exception err)  {
            Console.WriteLine(err);
        }
    }
}

internal class WorldsDumbestFunction
{
    internal string ReturnsPikachuIfZero(int number) => number switch
    {
        0 => "PIKACHU",
        _ => "SQUIRTLE",
    };

    public static void Main(string[] args)
    {
        WorldsDumbestFunction f = new();
        f.ReturnsPikachuIfZero(0);
        WorldsDumbestTest.WorldsDumbestTest_returnsPikachuIfero_ReturnsString();
    }
}

