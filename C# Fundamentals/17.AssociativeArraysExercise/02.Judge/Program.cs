namespace _02.Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> userAndContents
                        = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();
            while (input != "no more time")
            {
                string[] inputData = input.Split(" -> ");
                string userName = inputData[0];
                string contest = inputData[1];
                int points = int.Parse(inputData[2]);

                if (userAndContents.ContainsKey(contest) == false)
                {
                    userAndContents.Add(contest, new Dictionary<string, int> { { userName, points } });
                }
                else
                {
                    if (userAndContents[contest].ContainsKey(userName))
                    {
                        userAndContents[contest][userName] = userAndContents[contest][userName] < points ?
                            points : userAndContents[contest][userName];
                    }
                    else
                    {
                        userAndContents[contest].Add(userName, points);
                    }
                }

                input = Console.ReadLine();
            }

            int count = 1;
            foreach (string content in userAndContents.Keys)
            {
                Console.WriteLine($"{content}: {userAndContents[content].Count} participants");
                foreach (KeyValuePair<string, int> userAndPoints in userAndContents[content]
                    .OrderByDescending(v => v.Value).ThenBy(k => k.Key))
                {
                    Console.WriteLine($"{count++}. {userAndPoints.Key} <::> {userAndPoints.Value}");
                }
                count = 1;
            }
            count = 1;
            Console.WriteLine($"Individual standings:");

            Dictionary<string, int> userPoints = new Dictionary<string, int>();
            int sum = 0;
            foreach (string content in userAndContents.Keys)
            {
                foreach (string userName in userAndContents[content].Keys)
                {
                    if (userPoints.ContainsKey(userName) == false)
                    {
                        userPoints.Add(userName, userAndContents[content][userName]);
                    }
                    else
                    {
                        userPoints[userName] += userAndContents[content][userName];
                    }
                }
                sum = 0;
            }

            userPoints = userPoints.OrderByDescending(v => v.Value)
                                    .ThenBy(k => k.Key)
                                    .ToDictionary(k => k.Key, v => v.Value);

            foreach (var item in userPoints)
            {
                Console.WriteLine($"{count++}. {item.Key} -> {item.Value}");
            }
        }
    }
}