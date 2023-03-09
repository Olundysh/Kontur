namespace PremierLeague;

public static class Program
{
    public static void Main(string[] args)
    {
        var teamNum = int.Parse(Console.ReadLine());
        List<string> tournamentTable = new List<string>(teamNum);

        for (var i = 0; i < teamNum; i++)
        {
            tournamentTable.Add(Console.ReadLine());
        }

        var teams = Console.ReadLine().Split('-', 2);
        var teamA = teams[0];
        var teamB = teams[1];
        
        string teamAName = "";
        string teamBName = "";
        int teamAScore = 0;
        int teamBScore = 0;
        int teamAPosition = 0;

        for (var i = 0; i < teamNum; i++)
        {
            var temporal = tournamentTable[i].Split(' ', 2);
            if (temporal[0].Equals(teamA, StringComparison.OrdinalIgnoreCase))
            {
                teamAName = temporal[0];
                teamAScore = int.Parse(temporal[1]);
                teamAPosition = i + 1;
            }

            if (temporal[0].Equals(teamB, StringComparison.OrdinalIgnoreCase))
            {
                teamBName = temporal[0];
                teamBScore = int.Parse(temporal[1]);
            }
        }

        int win = teamAPosition;
        int equal = teamAPosition;
        int lose = teamAPosition;
        

        if (((teamAScore - teamBScore) == 3 && string.CompareOrdinal(teamBName, teamAName) > 0) ||
            (teamAScore - teamBScore) > 3 || teamAPosition == teamNum) lose = teamAPosition;
        else
        {
            lose = teamAPosition + 1;  
        }
        
        if (teamAPosition == 1)
        {
            win = teamAPosition;
            equal = teamAPosition;
            Console.WriteLine($"{win} {equal} {lose}");
            return;
        }
        
        for (var i = teamAPosition - 2; i >= 0; i--)
        {
            var temporal = tournamentTable[i].Split(' ', 2);
            
            if (int.Parse(temporal[1]) < teamAScore + 1)
            {
                equal = i + 1;
            }

            if (int.Parse(temporal[1]) == teamAScore + 1)
            {
                equal = string.CompareOrdinal(temporal[0], teamAName) > 0 ? i + 1 : teamAPosition;
            }

            if (int.Parse(temporal[1]) < teamAScore + 3)
            {
                win = i + 1;
                break;
            }

            if (int.Parse(temporal[1]) == teamAScore + 3)
            {
                win = string.CompareOrdinal(temporal[0], teamAName) > 0 ? i + 1 : teamAPosition;
                break;
            }
        }

        Console.WriteLine($"{win} {equal} {lose}");
    }
}