namespace MissingNumber;

public static class Program
{
    public static void Main(string[] args)
    {
        var arrLength = int.Parse(Console.ReadLine());
        var negativeNums = 0;
        var positiveNums = 0;
        for (var i = 0; i < arrLength; i++)
        {
            var number = int.Parse(Console.ReadLine());
            if (number < 0) negativeNums += number;
            if (number > 0) positiveNums += number;
        }
        Console.WriteLine(-(negativeNums + positiveNums));
    }
}
                                              