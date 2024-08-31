namespace _03.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Func<string[], string[]> currentText = words =>
            //{
            //    List<string> upperCaseWord = new List<string>();

            //    foreach (string word in words)
            //    {
            //        if (char.IsUpper(word[0]))
            //        {
            //            upperCaseWord.Add(word);
            //        }
            //    }

            //    return upperCaseWord.ToArray();
            //};

            //string[] text = Console.ReadLine()
            //                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            //PrintUppercaseWords(currentText(text));

            Func<string, bool> filter = text => char.IsUpper(text[0]);
            string text = Console.ReadLine();
            string[] words = text.Split();

            words = words.Where(filter).ToArray();

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }

        static void PrintUppercaseWords(string[] words)
        {
            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
