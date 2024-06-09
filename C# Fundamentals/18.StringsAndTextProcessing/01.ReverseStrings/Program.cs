namespace _01.ReverseStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input.ToLower() != "end")
            {
                ReverseString(input);

                input = Console.ReadLine();
            }
        }

        static void ReverseString(string text)
        {
            string reverse = string.Empty;

            for (int i = text.Length - 1; i >= 0; i--)
            {
                reverse += text[i];
            }

            Console.WriteLine(reverse);
        }

    }
}