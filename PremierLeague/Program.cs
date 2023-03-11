using System.Diagnostics;

namespace PremierLeague;

public static class Program
{
    private record TeamScore(string Name, int Score);
    
    public static void Main(string[] args)
    {
        var teamNum = int.Parse(Console.ReadLine()!);
        var tournamentTable = new List<TeamScore>(teamNum);

        for (var i = 0; i < teamNum; i++)
        {
            var temporal = Console.ReadLine()!.Split(' ', 2);
            tournamentTable.Add(new TeamScore(temporal[0], int.Parse(temporal[1])));
        }

        var teams = Console.ReadLine()!.Split('-', 2);

        TeamScore? teamA = null;
        TeamScore? teamB = null;
        var teamAPosition = 0;

        for (var i = 0; i < teamNum && (teamA is null || teamB is null); i++)
        {
            var team = tournamentTable[i];

            if (teamA is null && team.Name.Equals(teams[0], StringComparison.OrdinalIgnoreCase))
            {
                teamA = team;
                teamAPosition = i + 1;
            }
            else if (teamB is null && team.Name.Equals(teams[1], StringComparison.OrdinalIgnoreCase))
            {
                teamB = team;
            }
        }
        
        Debug.Assert(teamA is not null);
        Debug.Assert(teamB is not null);

        int win = teamAPosition;
        int equal = teamAPosition;
        int lose;

        if ((teamA.Score - teamB.Score == 3 && string.CompareOrdinal(teamB.Name, teamA.Name) > 0)
            || teamA.Score - teamB.Score > 3
            || teamAPosition == teamNum)
        {
            lose = teamAPosition;
        }
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
            var team = tournamentTable[i];
            
            if (team.Score < teamA.Score + 1)
            {
                equal = i + 1;
            }
            else if (team.Score == teamA.Score + 1)
            {
                equal = string.CompareOrdinal(team.Name, teamA.Name) > 0 ? i + 1 : teamAPosition;
            }

            if (team.Score < teamA.Score + 3)
            {
                win = i + 1;
                break;
            }

            if (team.Score == teamA.Score + 3)
            {
                win = string.CompareOrdinal(team.Name, teamA.Name) > 0 ? i + 1 : teamAPosition;
                break;
            }
        }

        Console.WriteLine($"{win} {equal} {lose}");
    }
}
