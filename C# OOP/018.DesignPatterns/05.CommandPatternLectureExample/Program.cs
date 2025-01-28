namespace _05.CommandPatternLectureExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User(new Calculator());

            while (true)
            {
                Console.WriteLine("Enter operation in format (fromat: + 5.3)");
                string[] split = Console.ReadLine().Split();

                if (split[0].Contains("undo"))
                {
                    int redoLevels = int.Parse(split[1]);
                    user.Calculator.Undo(redoLevels);
                }
                else
                {
                    char sing = split[0][0];
                    decimal value = decimal.Parse(split[1]);

                    user.Calculate(sing, value);
                }

                Console.WriteLine($"New value is: {user.Calculator.CurrentValue}");
            }
        }
    }
}
