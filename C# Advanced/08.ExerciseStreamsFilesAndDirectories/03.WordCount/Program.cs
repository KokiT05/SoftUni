namespace _03.WordCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] sumbols = { ",", ".", "-", "?", "!" };

            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            string[] words = File.ReadAllLines("../../../words.txt");

            foreach (string word in words)
            {
                if (!wordsCount.ContainsKey(word))
                {
                    wordsCount.Add(word, 0);
                }
            }

            string[] allText = File.ReadAllText("../../../text.txt").Split();
            foreach (string sumbol in sumbols)
            {
                for (int i = 0; i < allText.Length; i++)
                {
                    allText[i] = allText[i].Replace(sumbol, "");
                }
            }

            foreach (string text in allText)
            {
                if (wordsCount.ContainsKey(text.ToLower()))
                {
                    wordsCount[text.ToLower()]++;
                }
            }

            string[] result = GetStringArray(wordsCount);

            File.WriteAllLines("../../../expectedResult.txt", result);

            wordsCount = wordsCount.OrderByDescending(v => v.Value).ToDictionary(k => k.Key, v => v.Value);

            result = GetStringArray(wordsCount);

            File.WriteAllLines("../../../actualResult.txt", result);
        }

        static string[] GetStringArray(Dictionary<string, int> wordsCount)
        {
            string[] result = new string[wordsCount.Count];
            int count = 0;
            foreach (KeyValuePair<string, int> word in wordsCount)
            {
                result[count++] = $"{word.Key} - {word.Value}";
            }

            return result;
        }
    }
}
