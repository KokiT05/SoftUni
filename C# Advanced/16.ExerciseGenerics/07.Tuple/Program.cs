using System;

namespace _07.Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] personInformation = Console
                                        .ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string fullName = personInformation[0] + " " + personInformation[1];
            string addres = personInformation[2];
            Tuple<string, string> firstTyple = new Tuple<string, string>(fullName, addres);

            string[] beerInformation = Console.
                                        ReadLine().
                                        Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int litersBeer = int.Parse(beerInformation[1]);
            string name = beerInformation[0];
            Tuple<string, int> secondTuple = new Tuple<string, int>(name, litersBeer);
            //Tuple<string, int> secondTuple = new Tuple<string, int>(name, litersBeer);

            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int IntegerNumber = int.Parse(numbers[0]);
            double doubleNumber = double.Parse(numbers[1]);
            Tuple<int, double> thirdTuple = new Tuple<int, double>(IntegerNumber, doubleNumber);

            Console.WriteLine($"{firstTyple.ItemOne} -> {firstTyple.ItemTwo}");
            Console.WriteLine($"{secondTuple.ItemOne} -> {secondTuple.ItemTwo}");
            Console.WriteLine($"{thirdTuple.ItemOne} -> {thirdTuple.ItemTwo}");
        }
    }
}
