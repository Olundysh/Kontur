namespace StdInOut;

public static class Program
{
    public static void Main(string[] args)
    {
        var counter = 0;
        while (counter != 3)
        {
            // Console.WriteLine("Print your text");
            string? ourData = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(ourData))
            {
                counter++;
            }
            else
            {
                counter = 0;
                Console.WriteLine(ourData.Length);                
            }
        }
    }
}
