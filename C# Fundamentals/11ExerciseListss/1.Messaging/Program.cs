namespace _1.Messaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console
                                    .ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .ToList();

            List<char> text = Console.ReadLine().ToList();

            string result = string.Empty;

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumberInList = int.Parse(numbers[i]);
                int sum = 0;
                while (currentNumberInList != 0)
                {
                    int currentNumber = currentNumberInList % 10;
                    sum = sum + currentNumber;
                    currentNumberInList = currentNumberInList / 10;
                }

                if (sum > text.Count)
                {
                    sum = 0;
                }

                result = result + text[sum];
                text.RemoveAt(sum);
            }

            Console.WriteLine(result);
        }
    }
}