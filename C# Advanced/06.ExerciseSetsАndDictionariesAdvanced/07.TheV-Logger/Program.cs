namespace _07.TheV_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> app =
                new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            string commandInput = Console.ReadLine();

            while (commandInput != "Statistics")
            {
                string[] commandData = commandInput.Split(" ");
                string vloggerName = commandData[0];
                string command = commandData[1];

                if (command == "joined")
                {
                    if (!app.ContainsKey(vloggerName))
                    {
                        app.Add(vloggerName, new Dictionary<string, SortedSet<string>>());
                        app[vloggerName].Add("following", new SortedSet<string>());
                        app[vloggerName].Add("followers", new SortedSet<string>());
                    }
                }
                else if (command == "followed")
                {
                    string vloggerNameTwo = commandData[2];

                    if (app.ContainsKey(vloggerName) && app.ContainsKey(vloggerNameTwo) && vloggerName != vloggerNameTwo)
                    {
                        app[vloggerName]["following"].Add(vloggerNameTwo);
                        app[vloggerNameTwo]["followers"].Add(vloggerName);
                    }
                }

                commandInput = Console.ReadLine();
            }

            Dictionary<string, Dictionary<string, SortedSet<string>>> sortedDataApp =
                app.OrderByDescending(kvp => kvp.Value["followers"].Count)
                .ThenBy(kvp => kvp.Value["following"].Count)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            Console.WriteLine($"The V-Logger has a total of {app.Count} vloggers in its logs.");
            int counter = 0;

            foreach (KeyValuePair<string, Dictionary<string, SortedSet<string>>> vlogger in sortedDataApp)
            {
                int followersCount = vlogger.Value["followers"].Count;
                int followingCount = vlogger.Value["following"].Count;

                Console.WriteLine(
                $"{++counter}. {vlogger.Key} : {followersCount} followers, {followingCount} following");

                if (counter == 1)
                {
                    foreach (string follower in vlogger.Value["followers"])
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
            }


        }
    }
}
