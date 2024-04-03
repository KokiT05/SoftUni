using System.Text;

namespace _09.PalindromeIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            double number = 0;
            bool isPalindrome = false;
            while ((command = Console.ReadLine()) != "End")
            {
                number = double.Parse(command);

                isPalindrome = false;

                if (number >= 0)
                {
                    isPalindrome = IsPalindrome(command);
                }
                else
                {
                    continue;
                }

                if (isPalindrome)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }

        static bool IsPalindrome(string number)
        {
            StringBuilder reverseString = new StringBuilder();

            for (int i = number.Length - 1; i >= 0; i--)
            {
                reverseString.Append(number[i]);
            }

            if (string.Equals(number, reverseString.ToString()))
            {
                return true;
            }

            return false;
        }
    }
}