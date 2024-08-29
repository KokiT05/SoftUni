namespace _03.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, string[]> currentText = word =>
            {
                List<string> words = new List<string>();
                if (char.IsUpper(word[0]))
                {
                    words.Add(word);
                }

                return words.ToArray();
            };

            string text = Console.ReadLine();
            PrintUppercaseWords(currentText(text));
        }

        static void PrintUppercaseWords(string[] words)
        {
            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
