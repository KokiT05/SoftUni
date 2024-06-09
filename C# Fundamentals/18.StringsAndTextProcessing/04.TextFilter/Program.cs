namespace _04.TextFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] banWordsList = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();
            string replaceWord = string.Empty;

            foreach (string banWord in banWordsList) 
            {
                replaceWord = new string('*', banWord.Length);

                while (text.IndexOf(banWord) != -1)
                {
                    text = text.Replace(banWord, replaceWord);
                }
            }

            Console.WriteLine(text);
        }
    }
}