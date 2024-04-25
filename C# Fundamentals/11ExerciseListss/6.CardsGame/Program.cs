namespace _6.CardsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerCards = Console.ReadLine()
                                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                                .Select(int.Parse)
                                                .ToList();

            List<int> secondPlayerCards = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList();

            while (secondPlayerCards.Count != 0 && firstPlayerCards.Count != 0)
            {
                int firstPlayerCurrentCard = firstPlayerCards.First();
                int secondPlayerCurrentCard = secondPlayerCards.First();

                if (firstPlayerCurrentCard == secondPlayerCurrentCard)
                {
                    firstPlayerCards.RemoveAt(0);
                    secondPlayerCards.RemoveAt(0);
                }
                else if (firstPlayerCurrentCard > secondPlayerCurrentCard)
                {
                    firstPlayerCards.Add(firstPlayerCurrentCard);
                    firstPlayerCards.RemoveAt(0);
                    firstPlayerCards.Add(secondPlayerCurrentCard);
                    secondPlayerCards.RemoveAt(0);
                }
                else if (secondPlayerCurrentCard > firstPlayerCurrentCard) 
                {
                    secondPlayerCards.Add(secondPlayerCurrentCard);
                    secondPlayerCards.RemoveAt(0);
                    secondPlayerCards.Add(firstPlayerCurrentCard);
                    firstPlayerCards.RemoveAt(0);
                }
            }

            if (firstPlayerCards.Count > 0)
            {
                Console.WriteLine($"First player wins! Sum: {firstPlayerCards.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {secondPlayerCards.Sum()}");
            }
        }
    }
}