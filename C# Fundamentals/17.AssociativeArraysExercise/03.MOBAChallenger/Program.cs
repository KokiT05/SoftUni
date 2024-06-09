namespace _03.MOBAChallenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> playerData =
                new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();
            string[] inputData;
            string player = string.Empty;
            while (input != "Season end")
            {
                if (input.Contains("vs") == false)
                {
                    inputData = input.Split(" -> ");
                    player = inputData[0];
                    string position = inputData[1];
                    int points = int.Parse(inputData[2]);

                    if (playerData.ContainsKey(player) == false)
                    {
                        playerData.Add(player, new Dictionary<string, int> { { position, points } });
                    }

                    if (playerData[player].ContainsKey(position) == false)
                    {
                        playerData[player].Add(position, points);
                    }

                    playerData[player][position] = playerData[player][position] < points ?
                       points : playerData[player][position];

                }
                else
                {
                    inputData = input.Split(" vs ");
                    player = inputData[0];
                    string secondPlayer = inputData[1];

                    if (playerData.ContainsKey(player) && playerData.ContainsKey(secondPlayer))
                    {
                        foreach (string position in playerData[player].Keys)
                        {
                            if (playerData[secondPlayer].ContainsKey(position))
                            {
                                if (playerData[secondPlayer][position] < playerData[player][position])
                                {
                                    playerData.Remove(secondPlayer);
                                }
                                else if (playerData[secondPlayer][position] > playerData[player][position])
                                {
                                    playerData.Remove(player);
                                }
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Dictionary<string, int> playerTotalSkills = new Dictionary<string, int>(playerData.Count);

            foreach (string playerSkills in playerData.Keys)
            {
                playerTotalSkills.Add(playerSkills, playerData[playerSkills].Values.Sum());
            }

            playerTotalSkills = playerTotalSkills.OrderByDescending(v => v.Value).ThenBy(k => k.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (string currentPlayer in playerTotalSkills.Keys)
            {
                Console.WriteLine($"{currentPlayer}: {playerTotalSkills[currentPlayer]} skill");
                foreach (KeyValuePair<string, int> possitionAndSkills in playerData[currentPlayer]
                                    .OrderByDescending(v => v.Value).ThenBy(k => k.Key))
                {
                    Console.WriteLine($"- {possitionAndSkills.Key} <::> {possitionAndSkills.Value}");
                }
            }
        }
    }
}