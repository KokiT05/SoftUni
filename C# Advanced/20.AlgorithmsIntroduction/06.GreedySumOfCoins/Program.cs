namespace _06.GreedySumOfCoins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] availableCoins = new int[] { 1, 2, 5 };
            int targetSum = 2031154123;

            try
            {
                Dictionary<int, int> selectedCoins = ChooseCoinsFastMethod(availableCoins, targetSum);
                Console.WriteLine($"Number of coin to take: {selectedCoins.Values.Sum()}");
                foreach (KeyValuePair<int, int> coin in selectedCoins)
                {
                    Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
                }
            }
            catch (InvalidOperationException errorMessage)
            {
                Console.WriteLine(errorMessage.Message);
            }
        }

        public static Dictionary<int, int> ChooseCoinsFastMethod(int[] coins, int targetSum)
        {
            coins = coins.OrderByDescending(c => c).ToArray();

            Dictionary<int, int> chosenCoins = new Dictionary<int, int>();
            int currentSum = 0;

            for (int i = 0; i < coins.Length; i++)
            {
                int currentCoin = coins[i];

                if (currentSum + currentCoin > targetSum)
                {
                    continue;
                }

                int coinsToTake = (targetSum - currentSum) / currentCoin;
                currentSum += currentCoin * coinsToTake;

                chosenCoins.Add(currentCoin, coinsToTake);

                if (currentSum == targetSum)
                {
                    break;
                }
            }

            if (currentSum != targetSum)
            {
                throw new InvalidOperationException("Error");
            }

            return chosenCoins;
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
