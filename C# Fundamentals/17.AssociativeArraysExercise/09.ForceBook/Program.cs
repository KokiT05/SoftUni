namespace _09.ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input  = Console.ReadLine();
            Dictionary<string, List<string>> sideUsers = new Dictionary<string, List<string>>();
            while (input != "Lumpawaroo")
            {
                
                string firstArg = string.Empty;
                string characer = string.Empty;
                string secondArg =string.Empty;

                if (input.Contains("|"))
                {
                    string[] cmdArg = input.Split("|");
                    firstArg = cmdArg[0];
                    characer = cmdArg[1];
                    secondArg = cmdArg[2];
                }
                else if (input.Contains("->")) 
                {
                    string[] cmdArg = input.Split("->");
                    firstArg = cmdArg[0];
                    characer = cmdArg[1];
                    secondArg = cmdArg[2];
                }

                if (input.Contains('|') && sideUsers.ContainsKey(firstArg) == false)
                {
                    sideUsers.Add(firstArg, new List<string> { secondArg });
                }
                else if (input.Contains('|') && sideUsers[firstArg].Contains(secondArg) == false)
                {
                    sideUsers[firstArg].Add(secondArg);
                }

                bool isFound = false;
                if (input.Contains("->"))
                {
                    foreach (string forceUser in sideUsers.Keys)
                    {
                        if (sideUsers[forceUser].Contains(firstArg))
                        {
                            sideUsers[forceUser].Remove(firstArg);
                            sideUsers[secondArg].Add(firstArg);
                            Console.WriteLine($"{firstArg} joins the {secondArg} side!");
                            isFound = true;
                            break;
                        }
                    }

                    if (isFound == false && sideUsers.ContainsKey(secondArg))
                    {
                        sideUsers[secondArg].Add(firstArg);
                        Console.WriteLine($"{firstArg} joins the {secondArg} side!");
                    }
                    else if (isFound == false && sideUsers.ContainsKey(secondArg) == false)
                    {
                        sideUsers.Add(secondArg, new List<string> { firstArg });
                        Console.WriteLine($"{firstArg} joins the {secondArg} side!");
                    }
                }

                input = Console.ReadLine();
            }

            sideUsers = sideUsers.OrderByDescending(k => k.Value.Count)
                                .ThenBy(k => k.Key)
                                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var sideUser in sideUsers)
            {
                if (sideUsers[sideUser.Key].Count > 0)
                {
                    Console.WriteLine($"Side: {sideUser.Key}, Members: {sideUser.Value.Count}");
                    Console.WriteLine($"! {string.Join("\n! ", sideUser.Value.OrderBy(n => n))}");
                }
            }
        }
    }
}