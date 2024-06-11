namespace _02.AsciiSumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            string randomText = Console.ReadLine();

            int totalSum = 0;
            for (int i = 0; i < randomText.Length; i++)
            {
               totalSum += InRange(firstChar, secondChar, randomText[i]);
            }

            Console.WriteLine(totalSum);
        }

        static int InRange(char firstChar, char secondChar, char currentSumbol)
        {
            int bigLine = firstChar;
            int smallLine = secondChar;

            if (firstChar < secondChar)
            {
                bigLine = secondChar;
                smallLine = firstChar;
            }

            if (bigLine > currentSumbol && currentSumbol > smallLine)
            {
                return currentSumbol;
            }

            return 0;
        }
    }
}