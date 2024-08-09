namespace _07.TheV_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] inputArg;
            string firstVloget = string.Empty;
            string command = string.Empty;
            string secondVloger = string.Empty;

            string input = Console.ReadLine();

            HashSet<string> vloggers = new HashSet<string>();
            Dictionary<string, List<string>> followers = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> following = new Dictionary<string, List<string>>();

            while (input != "Statistics")
            {
                inputArg = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                firstVloget = inputArg[0];
                command = inputArg[1];

                if (command == "joined")
                {
                    vloggers.Add(firstVloget);

                    if (!followers.ContainsKey(firstVloget))
                    {
                        followers.Add(firstVloget, new List<string>());
                    }

                    if (!following.ContainsKey(firstVloget))
                    {
                        following.Add(firstVloget, new List<string>());
                    }
                }
                else if (command == "followed")
                {
                    secondVloger = inputArg[2];

                    if (vloggers.Contains(firstVloget) && 
                        vloggers.Contains(secondVloger) && 
                        (firstVloget != secondVloger) &&
                        !followers[secondVloger].Contains(firstVloget))
                    {
                        followers[secondVloger].Add(firstVloget);
                        following[firstVloget].Add(secondVloger);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs");

            followers = followers.OrderByDescending(v => v.Value.Count).ToDictionary(k => k.Key, v => v.Value);

            int mostFollowers = 0;
            int minimallyFollowed = 0;
            string famousVloger = string.Empty;
            foreach (string vloger in vloggers)
            {
                if (followers[vloger].Count > mostFollowers)
                {
                    mostFollowers = followers[vloger].Count;
                    minimallyFollowed = following[vloger].Count;
                    famousVloger = vloger;
                }
                else if (followers[vloger].Count == mostFollowers && following[vloger].Count < minimallyFollowed)
                {
                    mostFollowers = followers[vloger].Count;
                    minimallyFollowed = following[vloger].Count;
                    famousVloger = vloger;
                }
            }

            KeyValuePair<string, List<string>> famousVlogerFollowersList = followers.First(k => k.Key == famousVloger);
            Console.
            WriteLine
            ($"1. {famousVlogerFollowersList.Key} : " +
            $"{followers[famousVlogerFollowersList.Key].Count} followers, " +
            $"{following[famousVlogerFollowersList.Key].Count} following");
            foreach (string follower in famousVlogerFollowersList.Value)
            {
                Console.WriteLine($"*  {follower}");
            }

            followers.Remove(famousVloger);
            int count = 2;
            foreach (KeyValuePair<string, List<string>> vloger in followers)
            {
                Console.
                WriteLine($"{count}. {vloger.Key} : {vloger.Value.Count} followers, {following[vloger.Key].Count} following");
                count++;
            }

        }
    }
}
