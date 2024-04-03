namespace _06.MiddleCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string result = MiddleChar(text);
            Console.WriteLine(result);
        }

        static string MiddleChar(string text) 
        {
            string result = string.Empty;
            if ((text.Length % 2) == 0)
            {
                result = result + text[((text.Length - 1) / 2)];
                result = result + text[((text.Length - 1) / 2) + 1];
            }
            else
            {
                result = result + text[((text.Length - 1) / 2)];
            }

            return result;
        }
    }
}