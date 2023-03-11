namespace Playground;

public static class Program
{
    public static void Main(string[] args)
    {
        var nM = Console.ReadLine()!.Split(' ', 2);

        var n = int.Parse(nM[0]);
        var m = int.Parse(nM[1]);

        var horizontalStart = 0;
        var horizontalLength = 0;
        var counter = 1;
        
        for (var i = 0; i < n; i++)
        {
            var line = Console.ReadLine()!;
            var localCounter = 1;

            if (!line.Substring(horizontalStart, horizontalLength).Contains('*'))
            {
                localCounter++;
                if (localCounter > counter) counter = localCounter;
            }
            
            var localHorizontalStart = 0;
            var localHorizontalFinish = 0;
           
            for (var j = 1; j < m; j++)
            {
                if (line[j] == '.' && line[j - 1] == '*')
                {
                    localHorizontalStart = j;
                }

                if (line[j] == '*' && line[j - 1] == '.')
                {
                    localHorizontalFinish = j;
                }

                if (localHorizontalFinish - localHorizontalStart > horizontalLength)
                {
                    horizontalLength = localHorizontalFinish - localHorizontalStart;
                    horizontalStart = localHorizontalStart;
                }
               
            }
            
        }
        Console.WriteLine(horizontalLength * counter);
    }

}                                  
