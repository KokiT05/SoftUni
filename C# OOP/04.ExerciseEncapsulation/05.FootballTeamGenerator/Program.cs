namespace _05.FootballTeamGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] inputInformation = input.Split(';');
                string command = inputInformation[0];
                string teamName = inputInformation[1];

                try
                {
                    if (command == "Team")
                    {
                        AddTeam(teamName, teams);
                    }
                    else if (command == "Add")
                    {
                        if (!teams.ContainsKey(teamName))
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }

                        string playerName = inputInformation[2];
                        int endurance = int.Parse(inputInformation[3]);
                        int sprint = int.Parse(inputInformation[4]);
                        int dribble = int.Parse(inputInformation[5]);
                        int passing = int.Parse(inputInformation[6]);
                        int shooting = int.Parse(inputInformation[7]);

                        AddPlayerInTeam(teams[teamName], playerName,
                                                        endurance,
                                                        sprint,
                                                        dribble,
                                                        passing,
                                                        shooting);
                    }
                    else if (command == "Remove")
                    {
                        string playerName = inputInformation[2];
                        RemovePlayerFromTeam(playerName, teams[teamName]);
                    }
                    else if (command == "Rating")
                    {
                        if (!teams.ContainsKey(teamName))
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }

                        Console.WriteLine
                            ($"{teams[teamName].Name} - {teams[teamName].Rating}");
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

                input = Console.ReadLine();
            }


        }

        public static void AddTeam(string teamName, Dictionary<string, Team> teams)
        {
            Team team = new Team(teamName);
            teams.Add(teamName, team);
        }

        public static void AddPlayerInTeam(Team team, 
                                            string playerName,
                                            params int[] playerStats)
        {

            Player player = new Player
                                (playerName, 
                                playerStats[0], 
                                playerStats[1], 
                                playerStats[2],
                                playerStats[3],
                                playerStats[4]);

            team.AddPlayer(player);
        }

        public static void RemovePlayerFromTeam(string playerName, Team team)
        {
            team.RemovePlayer(playerName);
        }
    }
}
