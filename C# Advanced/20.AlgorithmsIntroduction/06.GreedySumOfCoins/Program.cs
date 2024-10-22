namespace _06.GreedySumOfCoins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] availableCoins = new int[] { 3, 7, 1 };
            int targetSum = 11;

            Dictionary<int, int> selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coin to take: {selectedCoins.Values.Sum()}");
            foreach (KeyValuePair<int, int> coin in selectedCoins)
            {
                Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(int[] coins, int targetSum)
        {
            coins = coins.OrderByDescending(c => c).ToArray();

            Dictionary<int, int> chosenCoins = new Dictionary<int, int>();
            int currentSum = 0;
            int currentCoinIndex = 0;

            while (currentSum != targetSum && currentCoinIndex < coins.Length)
            {
                int currentCoin = coins[currentCoinIndex];
                int remainingSum = targetSum - currentSum;
                int numberOfCoinsToTake = remainingSum / currentCoin;

                if (numberOfCoinsToTake > 0)
                {
                    chosenCoins.Add(currentCoin, numberOfCoinsToTake);
                    currentSum += currentCoin * numberOfCoinsToTake;
                }
                currentCoinIndex++;
            }

            if (currentSum != targetSum)
            {
                throw new InvalidOperationException("Error");
            }

            return chosenCoins;
        }
    }
}
