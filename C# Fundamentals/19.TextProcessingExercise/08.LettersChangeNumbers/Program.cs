namespace _08.LettersChangeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputData =
                Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double totalAmount = 0;
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int StartCharacterPossition = -1;
            int EndCharacterPossition = -1;
            double number = 0;

            foreach (string input in inputData)
            {
                number = 0;
                StartCharacterPossition = alphabet.IndexOf(char.ToUpper(input[0])) + 1;
                EndCharacterPossition = 
                alphabet.IndexOf(char.ToUpper(input[input.Length - 1])) + 1;
                number = int.Parse(input.Substring(1, input.Length - 2));

                if (StartCharacterPossition != -1 &&
                    (input[0] >= 65 && input[0] <= 90))
                {
                    number = number / StartCharacterPossition;
                }
                else if (StartCharacterPossition != -1 &&
                    (input[0] >= 97 && input[0] <= 122))
                {
                    number = number * StartCharacterPossition;
                }

                if (EndCharacterPossition != -1 &&
                    (input[input.Length - 1] >= 65 && input[input.Length - 1] <= 90))
                {
                    number = number - EndCharacterPossition;
                }
                else if (EndCharacterPossition != -1 &&
                    (input[input.Length - 1] >= 97 && input[input.Length - 1] <= 122))
                {
                    number = number + EndCharacterPossition;
                }

                totalAmount += number;
            }

            Console.WriteLine($"{totalAmount:f2}");
        }
    }
}