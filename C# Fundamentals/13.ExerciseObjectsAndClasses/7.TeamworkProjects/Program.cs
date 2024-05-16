using System;

namespace _7.TeamworkProjects
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var n = int.Parse(Console.ReadLine());
            int s = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                var num = int.Parse(Console.ReadLine());
                if (num > s)
                {
                    s = num;
                }
            }

            Console.WriteLine(s);
            //    List<Team> teams = new List<Team>();

            //    int countOfTeam = int.Parse(Console.ReadLine());
            //    for (int i = 1; i <= countOfTeam; i++)
            //    {
            //        string[] inputData = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries);
            //        string creator = inputData[0];
            //        string teamName = inputData[1];
            //        Team team = new Team(teamName, creator);

            //        bool isTeamExist = teams.Select(t => t.TeamName).Contains(teamName);
            //        bool isCreatorExist = teams.Select(t => t.Creator).Contains(creator);

            //        if(!isTeamExist)
            //        {
            //            if (!isCreatorExist)
            //            {
            //                teams.Add(team);
            //                Console.WriteLine($"Team {teamName} has been created by {creator}!");
            //            }
            //            else
            //            {
            //                Console.WriteLine($"{creator} cannot create another team!");
            //            }
            //        }
            //        else
            //        {
            //            Console.WriteLine($"Team {teamName} was already created!");
            //        }
            //    }

            //    string command = Console.ReadLine();
            //    while (command != "end of assignment")
            //    {
            //        string[] cmdArg = command.Split("->", StringSplitOptions.RemoveEmptyEntries);
            //        string member = cmdArg[0];
            //        string team = cmdArg[1];

            //        bool isTeamExist = teams.Select(t => t.TeamName).Contains(team);

            //        if (isTeamExist)
            //        {
            //            bool isMemberExist = teams.Any(t => t.Members.Contains(member));
            //            bool isCreatorAreMember = teams.Select(t => t.Creator).Contains(member);

            //            if (isMemberExist || isCreatorAreMember)
            //            {
            //                Console.WriteLine($"Member {member} cannot join team {team}!");
            //            }
            //            else
            //            {
            //                int indexOfTeam = teams.FindIndex(t => t.TeamName.Equals(team));
            //                teams[indexOfTeam].Members.Add(member);
            //            }
            //        }
            //        else
            //        {
            //            Console.WriteLine($"Team {team} does not exist!");
            //        }


            //        command = Console.ReadLine();
            //    }

            //    Team[] onlyZeroMembers = teams.Where(t => t.Members.Count == 0).Select(t => t).ToArray();
            //    Team[] teamsWithMembers = teams.Where(t => t.Members.Count > 0).Select(t => t).ToArray();

            //    teamsWithMembers = teamsWithMembers
            //                                    .OrderByDescending(t => t.Members.Count)
            //                                    .ThenBy(t => t.TeamName)
            //                                    .ToArray();

            //    onlyZeroMembers = onlyZeroMembers.OrderBy(t => t.TeamName).ToArray();

            //    foreach (Team team in teamsWithMembers)
            //    {
            //        Console.WriteLine($"{team.TeamName}");
            //        Console.WriteLine($"- {team.Creator}");
            //        foreach (string member in team.Members.OrderBy(n => n))
            //        {
            //            Console.WriteLine($"-- {member}");
            //        }
            //    }

            //    Console.WriteLine("Teams to disband:");
            //    foreach (Team team in onlyZeroMembers)
            //    {
            //        Console.WriteLine($"{team.TeamName}");
            //    }
            //}
        }
    }

    public class Team
    {
        public Team(string teamName, string creator)
        {
            this.TeamName = teamName;
            this.Creator = creator;
            this.Members = new List<string>();
        }

        public string TeamName { get; set; }

        public string Creator { get; set; }

        public List<string> Members { get; set; }
    }
}