namespace _03.WordCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expectedResultPath = Path.Combine("..", "..", "..", "actualResult.txt");

            string[] words = File.ReadAllLines("../../../words.txt");
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            foreach (string word in words)
            {
                wordsCount.Add(word.ToLower(), 0);
            }

            string text = File.ReadAllText("../../../text.txt").ToLower();
            string[] textWords = text.Split
                (new string[] { " ", ",", ".", "!", "?", "-", Environment.NewLine } , 
                StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in textWords)
            {
                if (wordsCount.ContainsKey(word))
                {
                    wordsCount[word]++;
                }
            }

            List<string> result = wordsCount.Select(kvp => $"{kvp.Key} - {kvp.Value}").ToList();
            File.WriteAllLines("../../../expectedResult.txt", result);

            Dictionary<string, int> sortedWords = wordsCount.OrderByDescending(v => v.Value)
                                                            .ToDictionary(k => k.Key, v => v.Value);

            result = sortedWords.Select(kvp => $"{kvp.Key} - {kvp.Value}").ToList();

            File.WriteAllLines(expectedResultPath, result);

            //string[] sumbols = { ",", ".", "-", "?", "!" };

            //Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            //string[] words = File.ReadAllLines("../../../words.txt");

            //foreach (string word in words)
            //{
            //    if (!wordsCount.ContainsKey(word))
            //    {
            //        wordsCount.Add(word, 0);
            //    }
            //}

            //string[] allText = File.ReadAllText("../../../text.txt").Split();
            //foreach (string sumbol in sumbols)
            //{
            //    for (int i = 0; i < allText.Length; i++)
            //    {
            //        allText[i] = allText[i].Replace(sumbol, "");
            //    }
            //}

            //foreach (string text in allText)
            //{
            //    if (wordsCount.ContainsKey(text.ToLower()))
            //    {
            //        wordsCount[text.ToLower()]++;
            //    }
            //}

            //string[] result = GetStringArray(wordsCount);

            //File.WriteAllLines("../../../expectedResult.txt", result);

            //wordsCount = wordsCount.OrderByDescending(v => v.Value).ToDictionary(k => k.Key, v => v.Value);

            //result = GetStringArray(wordsCount);

            //File.WriteAllLines("../../../actualResult.txt", result);
        }

        //static string[] GetStringArray(Dictionary<string, int> wordsCount)
        //{
        //    string[] result = new string[wordsCount.Count];
        //    int count = 0;
        //    foreach (KeyValuePair<string, int> word in wordsCount)
        //    {
        //        result[count++] = $"{word.Key} - {word.Value}";
        //    }

        //    return result;
        //}
    }
}
