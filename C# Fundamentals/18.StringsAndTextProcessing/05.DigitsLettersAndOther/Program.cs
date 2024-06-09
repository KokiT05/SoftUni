namespace _05.DigitsLettersAndOther
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string onlyLetters = string.Empty;
            string onlyDigits = string.Empty;
            string others = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]))
                {
                    onlyLetters += input[i];
                }
                else if (char.IsDigit(input[i])) 
                {
                    onlyDigits += input[i];
                }
                else
                {
                    others += input[i];
                }
            }

            Console.WriteLine(onlyDigits);
            Console.WriteLine(onlyLetters);
            Console.WriteLine(others);
        }
    }
}