namespace _5.RecursionPalindrome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            bool isPalindrom = Palindrome(text);
            Console.WriteLine($"Is palindrome: {isPalindrom}");
        }

        public static bool Palindrome(string text)
        {
            if (text.Length  <= 1)
            {
                return true;
            }

            if (text[0] == text[text.Length - 1])
            {
                return true;
            }
            else
            {
                return false;
            }

            text = text.Substring(1, text.Length - 2);
            return Palindrome(text);
        }
    }
}
