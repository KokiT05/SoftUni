using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string digitPattern = @"[\d]";
            string emojiPattern = @"([\:]{2}|[\*]{2})([A-Z][a-z]{2,})\1";
            Regex regex = new Regex(digitPattern);
            MatchCollection matchCollection = regex.Matches(input);

            // TODO: maybe double or int!!!
            int coolThreshold = 1;

            for (int i = 0; i < matchCollection.Count; i++)
            {
                coolThreshold *= int.Parse(matchCollection[i].Value);
            }

            regex = new Regex(emojiPattern);
            matchCollection = regex.Matches(input);

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{matchCollection.Count} emojis found in the text. The cool ones are:");

            int countOfASCII = 0;
            foreach (Match match in matchCollection)
            {
                string emoji = match.Groups[2].Value;
                for (int i = 0; i < emoji.Length; i++)
                {
                    countOfASCII += emoji[i];
                }

                if (countOfASCII >= coolThreshold)
                {
                    Console.WriteLine(match.Groups[0].Value);

                }
                countOfASCII = 0;
            }

        }
    }
}