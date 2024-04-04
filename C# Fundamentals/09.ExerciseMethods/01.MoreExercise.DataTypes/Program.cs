namespace _01.MoreExercise.DataTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            string value = Console.ReadLine();

            if (command == "int")
            {
                Integer(value);
            }
            else if (command == "real")
            {
                RealNumber(value);
            }
            else if (command == "string")
            {
                String(value);
            }
        }

        static void Integer(string value)
        {
            int number = int.Parse(value);

            number = number * 2;
            Console.WriteLine(number);
        }

        static void String(string value)
        {
            string newText = "$" + value + "$";
            Console.WriteLine(newText);
        }

        static void RealNumber(string value)
        {
            double realNumber = double.Parse(value);

            realNumber = realNumber * 1.5;

            Console.WriteLine($"{realNumber:f2}");
        }
    }
}