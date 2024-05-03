namespace _7.TeamworkProjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfTeam = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>(countOfTeam);

            string[] input = new string[2];
            for (int i = 1; i <= countOfTeam; i++)
            {
                input = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries);
                string creator = input[0];
                string teamName = input[1];

                foreach (Team currentTeam in teams)
                {
                    if (currentTeam.TeamName != teamName )
                    {
                        Team team = new Team(creator, teamName);
                        teams.Add(team);
                    }
                    else
                    {
                        Console.WriteLine($"Team {teamName} was alredy created!");
                    }

                    if (currentTeam.Creator != creator)
                    {
                        Team team = new Team(creator, teamName);
                        teams.Add(team);
                    }
                    else
                    {
                        Console.WriteLine($"{creator} cannot create another team!");
                    }
                }
            }

            string command = Console.ReadLine();
            while ((command = Console.ReadLine()) != "end of assignment")
            {
                input = command.Split("->", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                string teamName = input[1];
                Member member = new Member(name);

                bool isExistentTeam = false;
                foreach (Team team in teams)
                {
                    if (team.TeamName == teamName)
                    {
                        isExistentTeam = true;
                        break;
                    }
                }

                if (!isExistentTeam)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                bool isAlredyInTeam = false;
                foreach (Team team in teams)
                {
                    foreach (Member memberInTeam in team.Members)
                    {
                        if (memberInTeam.Name == name)
                        {
                            isAlredyInTeam = true;
                        }
                    }
                }

                if (!isAlredyInTeam)
                {
                    Console.WriteLine($"Member {name} cannot join team {teamName}!");
                }

                foreach (Team team in teams)
                {

                    if (team.TeamName == teamName)
                    {
                        team.Members.Add(member);
                    }
                }
            }

            List<Team> zeroMembers = teams.Where(t => t.Members.Count == 0).ToList();
            zeroMembers = zeroMembers.OrderBy(t => t.TeamName).ToList();
            foreach (Team team in zeroMembers)
            {
                Console.WriteLine($"{team.TeamName}");
            }

            foreach (Team team in teams.Where(t => t.Members.Count > 0))
            {
                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"-{team.Creator}");
                Console.WriteLine($"--{string.Join(' ', team.Members)}");
            }
        }
    }

    public class Team
    {
        public Team(string creator, string teamName)
        {
            this.TeamName = teamName;
            this.Creator = creator;
            this.Members = new List<string>();
        }

        public string Creator { get; set; }

        public string TeamName { get; set; }

        public List<string> Members { get; set; }
    }

    public class Member
    {
        public Member(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}