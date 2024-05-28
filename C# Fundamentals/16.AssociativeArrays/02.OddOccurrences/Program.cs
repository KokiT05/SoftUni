namespace _02.OddOccurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ');

            Dictionary<string, int> countOfWords = new Dictionary<string, int>();

            foreach (string word in words) 
            {
                string wordInLower = word.ToLower();
                if (countOfWords.ContainsKey(wordInLower))
                {
                    countOfWords[wordInLower]++;
                }
                else
                {
                    countOfWords.Add(wordInLower, 1);
                }
            }

            foreach (string word in countOfWords.Keys) 
            {
                if (countOfWords[word] % 2 != 0)
                {
                    Console.Write($"{word} ");
                }
            }
        }
    }
}