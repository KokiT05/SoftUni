namespace _03.WordSynonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> wordsSynonyms = new Dictionary<string, List<string>>(count);
            for (int i = 0; i < count; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (wordsSynonyms.ContainsKey(word))
                {
                    wordsSynonyms[word].Add(synonym);
                }
                else
                {
                    wordsSynonyms.Add(word, new List<string> { synonym} );
                }
            }

            foreach (KeyValuePair<string, List<string>> words in wordsSynonyms)
            {
                Console.WriteLine($"{words.Key} - {string.Join(", ", words.Value)}");
            }
        }
    }
}