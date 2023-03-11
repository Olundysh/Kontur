using System.Collections;

namespace StdInOut;

public static class Program
{
    private class StdInEnumerator : IEnumerator<string>
    {
        /// <inheritdoc />
        public bool MoveNext()
        {
            var counter = 0;
            while (counter != 3)
            {
                string? nextLine = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nextLine))
                {
                    counter++;
                }
                else
                {
                    Current = nextLine;
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc />
        public void Reset()
        {
            Console.WriteLine("Enumerator reset");
        }

        /// <inheritdoc />
        public string Current { get; private set; } = null!;

        /// <inheritdoc />
        object IEnumerator.Current => Current;

        /// <inheritdoc />
        public void Dispose()
        {
            Console.WriteLine("Enumerator disposed");
        }
    }
    
    private class StdInReader : IEnumerable<string>
    {
        /// <inheritdoc />
        public IEnumerator<string> GetEnumerator()
        {
            return new StdInEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    private static IEnumerable<string> ReadStdIn()
    {
        var counter = 0;
        while (counter != 3)
        {
            string? nextLing = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nextLing))
            {
                counter++;
            }
            else
            {
                counter = 0;
                yield return nextLing;
            }
        }
    }

    static int GetLength(string s)
    {
        return s.Length;
    }

    public static void Main(string[] args)
    {
        var reader = new StdInReader();

        foreach (var val in reader.Select(GetLength))
        {
            Console.WriteLine(val);
        }
    }
}
