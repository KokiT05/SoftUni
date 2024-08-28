using System.Text;

namespace _02.LineNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string outputFilePath = Path.Combine("..", "..", "..", "output.txt");
            string[] lines = File.ReadAllLines("../../../text.txt");

            List<char> punctuationMarks = new List<char>() { '-', ',', '.', '!', '?', '\''};

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                int lettersCount = 0;
                int punctuationMarksCount = 0;

                foreach (char ch in line)
                {
                    if (char.IsLetter(ch))
                    {
                        lettersCount++;
                    }
                    else if (punctuationMarks.Contains(ch))
                    {
                        punctuationMarksCount++;
                    }
                }

                string newLine = $"Line {i + 1}: {line} ({lettersCount})({punctuationMarksCount})";
                File.AppendAllText(outputFilePath, newLine + Environment.NewLine);
            }

            //char[] punctuationMarks = new char[] { '.', ',', '!', '?', '\'', '-' };
            //int countPunctuationMarks = 0;
            //int countLetters = 0;

            //string[] text = File.ReadLines("../../../text.txt").ToArray();
            //string[] result = new string[text.Length];

            //for (int i = 0; i < text.Length; i++)
            //{
            //    for (int j = 0; j < text[i].Length; j++)
            //    {
            //        countPunctuationMarks = CountPunctuationMarks(punctuationMarks, text[i]);
            //        countLetters = CountLetters(text[i]);
            //    }

            //    result[i] = $"Line {i + 1}: " + text[i] + $" ({countLetters})({countPunctuationMarks})";
            //}

            //File.WriteAllLines("../../../output.txt", result);
        }

        //static int CountPunctuationMarks(char[] punctuationMarks, string text)
        //{
        //    int countOfPunctuationMarks = 0;
        //    for (int i = 0; i < punctuationMarks.Length; i++)
        //    {
        //        for (int j = 0; j < text.Length; j++)
        //        {
        //            if (punctuationMarks[i] == text[j])
        //            {
        //                countOfPunctuationMarks++;
        //            }
        //        }
        //    }

        //    return countOfPunctuationMarks;
        //}

        //static int CountLetters(string text)
        //{
        //    int countOfLetters = 0;
        //    for (int i = 0; i < text.Length; i++)
        //    {
        //        if (char.IsLetter(text[i]))
        //        {
        //            countOfLetters++;
        //        }
        //    }

        //    return countOfLetters;
        //}
    }
}
