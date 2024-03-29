namespace _04._4FoldАndSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console
                            .ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            int k = numbers.Length / 4;

            int[] firstSide = new int[k];
            int[] secondSide = new int[k];
            int[] result = new int[numbers.Length / 2];

            for (int i = 0; i < k; i++)
            {
                firstSide[i] = numbers[i];
            }

            int startIndex = 0;
            for (int i = numbers.Length - 1; i > numbers.Length - (k + 1); i--)
            {
                int number = numbers[i];
                secondSide[startIndex] = number;
                startIndex++;
            }
            int index = k;
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = numbers[index];
                index++;
            }

            Array.Reverse(firstSide);
            

            for (int i = 0; i < k; i++)
            {
                Console.Write($"{firstSide[i] + result[i]} ");
            }

            for (int i = k; i > 0; i--)
            {
                Console.Write($"{secondSide[secondSide.Length - i] + result[result.Length - i]} ");
            }
        }
    }
}