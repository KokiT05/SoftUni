namespace _01.ValidUsernames
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(", ");

            bool isCorrectName = true;

            foreach (string name in names)
            {
                for (int i = 0; i < name.Length; i++)
                {
                    if (!IsCorrectSymbol(name[i]))
                    {
                        isCorrectName = false;
                    }
                }

                if (isCorrectName && IsCorrectLength(name))
                {
                    Console.WriteLine(name);
                }

                isCorrectName = true;
            }
        }

        static bool IsCorrectLength(string text)
        {
            if (text.Length >= 3 && text.Length <= 16)
            {
                return true;
            }

            return false;
        }

        static bool IsCorrectSymbol(char symbol)
        {
            if (char.IsLetter(symbol) || char.IsDigit(symbol) || symbol == '-' || symbol == '_')
            {
                return true;
            }

            return false;
        }
    }
}