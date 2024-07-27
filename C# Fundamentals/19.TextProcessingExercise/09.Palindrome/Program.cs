namespace _09.Palindrome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int maxLen = 0;
            for (int i = 0; i < input.Length; i++)
            {
                maxLen = Math.Max(maxLen, PalindromeLen(input, i, i));
            }

            for (int i = 0; i < input.Length; i++)
            {
                maxLen = Math.Max(maxLen, PalindromeLen(input, i, i + 1));
            }

            Console.WriteLine(maxLen);
        }

        static int PalindromeLen(string input, int leftIndex, int rightIndex)
        {
            while (leftIndex >= 0 && rightIndex < input.Length &&
                input[leftIndex] == input[rightIndex])
            {
                leftIndex--;
                rightIndex++;
            }

            return rightIndex - leftIndex - 1;
        }
    }
}