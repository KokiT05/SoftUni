namespace _05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            SortedDictionary<char, int> charsCount = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!charsCount.ContainsKey(input[i]))
                {
                    charsCount.Add(input[i], 0);
                }

                charsCount[input[i]]++;
            }

            foreach (KeyValuePair<char, int> @char in charsCount)
            {
                Console.WriteLine($"{@char.Key}: {@char.Value} time/s");
            }
        }
    }
}
