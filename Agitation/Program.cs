using System.Text;
using static System.Char;

namespace Agitation;

public static class Program
{
    private static ValueTuple <string, int> StreetNameHouseSeparator(string streetNameHouse)
    {
        var name = new StringBuilder(streetNameHouse.Length - 1);
        var result = new ValueTuple<string, int>();

        for (var j = 0; j < streetNameHouse.Length; j++)
        {
            if(IsLetter(streetNameHouse[j]))
            {
                name.Append(streetNameHouse[j]);
            }
            else
            {
                result.Item1 = name.ToString();
                result.Item2 = int.Parse(streetNameHouse[j..]); 
                break;
            }
        }
        return result;
    }
    
    public static void Main(string[] args)
    {
        var firstDayBuildingsNumber = int.Parse(Console.ReadLine());
        var firstDayList = new List<ValueTuple<string, int>>(firstDayBuildingsNumber);
        
        for (var i = 0; i < firstDayBuildingsNumber; i++)
        {
            var address = StreetNameHouseSeparator(Console.ReadLine());
        
            firstDayList.Add(address);
        }
        
        var secondDayBuildingsNumber = int.Parse(Console.ReadLine());
        for (var i = 0; i < secondDayBuildingsNumber; i++)
        {
            var street = Console.ReadLine();
            foreach (var t in firstDayList)
            {
                var usedNumbers = new StringBuilder();
                if (firstDayList[i].Item1.Equals(street))
                {
                    usedNumbers.Append($"*{firstDayList[i].Item2}*");
                }
            }
            
            
            
        }
       
    }
}