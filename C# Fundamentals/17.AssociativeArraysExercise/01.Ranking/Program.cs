namespace _01.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contentPasswords = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> userContents
                = new Dictionary<string, Dictionary<string, int>>();

            string[] inputData;
            string input = Console.ReadLine();
            while (input != "end of contests")
            {
                inputData = input.Split(':');
                string content = inputData[0];
                string password = inputData[1];

                if (contentPasswords.ContainsKey(content) == false)
                {
                    contentPasswords.Add(content, password);
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "end of submissions")
            {
                inputData = input.Split("=>");
                string content = inputData[0];
                string password = inputData[1];
                string user = inputData[2];
                int points = int.Parse(inputData[3]);

                if (contentPasswords.ContainsKey(content) && contentPasswords[content] == password)
                {
                    //!!!!!!!!
                    if (userContents.ContainsKey(user) == false)
                    {
                        userContents.Add(user, new Dictionary<string, int> { { content, points } });
                    }
                    else
                    {
                        if (userContents[user].ContainsKey(content) == false)
                        {
                            userContents[user].Add(content, points);
                        }
                        else
                        {
                            userContents[user][content] = userContents[user][content] < points
                                ? points : userContents[user][content];
                        }
                    }
                }

                input = Console.ReadLine();
            }

            string bestCandidate = string.Empty;
            int bestPoint = 0;
            foreach (string user in userContents.Keys)
            {
                foreach (KeyValuePair<string, int> contentAndPoints in userContents[user])
                {
                    if (userContents[user].Values.Sum() > bestPoint)
                    {
                        bestPoint = userContents[user].Values.Sum();
                        bestCandidate = user;
                    }
                }
            }

            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestPoint} points.");

            userContents = userContents.OrderBy(x => x.Key).ToDictionary(k => k.Key, v => v.Value);
            Console.WriteLine("Ranking: ");
            foreach (string user in userContents.Keys)
            {
                Console.WriteLine($"{user}");
                foreach (KeyValuePair<string, int> contentPoints in 
                    userContents[user].OrderByDescending(v => v.Value))
                {
                    Console.WriteLine($"#  {contentPoints.Key} -> {contentPoints.Value}");
                }
            }
        }
    }
}