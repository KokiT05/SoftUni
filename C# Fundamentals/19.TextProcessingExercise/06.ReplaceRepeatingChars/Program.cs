namespace _06.ReplaceRepeatingChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            input = StringModification(input);

            Console.WriteLine(input);
        }

        public static string StringModification(string input)
        {
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

                input = RemoveUnnecessaryPart(input, countOfSequence, i);

                countOfSequence = 0;
            }

            return input;
        }

        public static string RemoveUnnecessaryPart(string input, int countOfSequence, int index)
        {
            if (countOfSequence >= 2)
            {
                input = input.Remove(index, countOfSequence - 1);
            }

            return input;
        }
    }
}