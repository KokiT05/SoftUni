using System.Text;

namespace _02.LineNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] punctuationMarks = new char[] { '.', ',', '!', '?', '\'', '-' };
            int countPunctuationMarks = 0;
            int countLetters = 0;

            string[] text = File.ReadLines("../../../text.txt").ToArray();
            string[] result = new string[text.Length];
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < text[i].Length; j++)
                {
                    countPunctuationMarks = CountPunctuationMarks(punctuationMarks, text[i]);
                    countLetters = CountLetters(text[i]);
                }

                text[i] = $"Line {i + 1}: " + text[i] + $" ({countLetters})({countPunctuationMarks})";
                result[i] = text[i];
            }

            File.WriteAllLines("../../../output.txt", result);
        }

        static int CountPunctuationMarks(char[] punctuationMarks, string text)
        {
            int countOfPunctuationMarks = 0;
            for (int i = 0; i < punctuationMarks.Length; i++)
            {
                for (int j = 0; j < text.Length; j++)
                {
                    if (punctuationMarks[i] == text[j])
                    {
                        countOfPunctuationMarks++;
                    }
                }
            }

            return countOfPunctuationMarks;
        }

        static int CountLetters(string text)
        {
            int countOfLetters = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    countOfLetters++;
                }
            }

            return countOfLetters;
        }
    }
}
