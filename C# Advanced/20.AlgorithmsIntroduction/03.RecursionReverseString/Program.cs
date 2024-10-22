namespace _03.RecursionReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine();
            string result = ReverseString(inputText, inputText.Length - 1);
            Console.WriteLine(result);
        }

        public static string ReverseString(string text, int startIndex)
        {
            if (startIndex == 0 || text.Length == 1)
            {
                return text[startIndex].ToString();
            }

            return text[startIndex] + ReverseString(text, startIndex - 1);
        }
    }
}
