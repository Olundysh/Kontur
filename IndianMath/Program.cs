namespace IndianMath;

public static class Program
{
    public static void Main ()
    {
        string input = Console.ReadLine()!;
        var max = long.Parse(new string(input.OrderByDescending(c => c).ToArray()));
        var min = long.Parse(new string(input.OrderBy(c => c).ToArray()));
        Console.WriteLine(max - min);
    }
}
