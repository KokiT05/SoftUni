namespace _01.ExtractPersonInformation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            int[] indexes = new int[4];
            string currentName = string.Empty;
            string currentAge = string.Empty;

            for (int i = 1; i <= lines; i++)
            {
                string input = Console.ReadLine();
                indexes = SumbolsArray(input, indexes);

                currentName =
                input.Substring(indexes[0] + 1, (indexes[1] - (indexes[0] + 1)));
                currentAge =
                input.Substring(indexes[2] + 1, (indexes[3] - (indexes[2] + 1)));

                Console.WriteLine($"{currentName} is {currentAge} years old.");
            }
        }

        static bool isExist(char character, string text)
        {
            if (text.IndexOf(character) != -1)
            {
                return true;
            }

            return false;
        }

        static int[] SumbolsArray(string text, int[] sumbolArray)
        {
            int count = 0;
            if (isExist('@', text))
            {
                sumbolArray[count] = text.IndexOf('@');
            }
            count++;
            if (isExist('|', text))
            {
                sumbolArray[count] = text.IndexOf('|');
            }
            count++;
            if (isExist('#', text))
            {
                sumbolArray[count] = text.IndexOf('#');
            }
            count++;
            if (isExist('*', text))
            {
                sumbolArray[count] = text.IndexOf('*');
            }

            return sumbolArray;
        }
    }
}