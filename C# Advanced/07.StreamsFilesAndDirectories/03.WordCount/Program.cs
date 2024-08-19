using System.Text;

namespace _03.WordCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            string text = string.Empty;
            string[] words;
            using (StreamReader streamReader = new StreamReader("../../../Words.txt"))
            {
                text = streamReader.ReadToEnd();
                while (text != null)
                {
                    words = text.Split(" ");
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (!wordsCount.ContainsKey(words[i]))
                        {
                            wordsCount.Add(words[i], 0);
                        }
                    }
                    text = streamReader.ReadLine();
                }
            }

            using (StreamReader streamReader = new StreamReader("../../../Input.txt"))
            {
                text = streamReader.ReadLine();
                while (text != null)
                {
                    words = text.Split(new char[] { ' ', '-', ',', '.', '!', '?'})
                        .Select(word => word.ToLower())
                        .ToArray();
                    foreach (string word in words)
                    {
                        if (wordsCount.ContainsKey(word))
                        {
                            wordsCount[word]++;
                        }
                    }
                    text = streamReader.ReadLine();
                }
            }

            wordsCount = wordsCount.OrderByDescending(x => x.Value)
                                    .ToDictionary(key => key.Key, value => value.Value);

            using (StreamWriter streamWriter = new StreamWriter("../../../Output.txt"))
            {
                foreach (KeyValuePair<string, int> word in wordsCount)
                {
                    streamWriter.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
