namespace _06.ReplaceRepeatingChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int countOfSequence = 0;

            char firstSymbol = input[0];
            int index = 0;

            for (int i = 0; i < input.Length; i++)
            {
                firstSymbol = input[i];

                for (int j = i; j < input.Length; j++)
                {
                    if (firstSymbol == input[j])
                    {
                        countOfSequence++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (countOfSequence >= 2)
                {
                    input = input.Remove(i, countOfSequence - 1);
                }

                countOfSequence = 0;

            }

            Console.WriteLine(input);
        }
    }
}