using System.Globalization;

namespace _06.HeartDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] house = Console.ReadLine().Split('@').Select(int.Parse).ToArray();

            int love = 2;
            int index = 0;
            string input = Console.ReadLine();
            while (input != "Love!")
            {
                string[] inputData = input.Split(' ');
                string command = inputData[0];
                int length = int.Parse(inputData[1]);

                if (command == "Jump")
                {

                    index = index + length;

                    if (index >= house.Length)
                    {
                        index = 0;
                    }


                    if (house[index] - 2 == 0)
                    {
                        Console.WriteLine($"Place {index} has Valentine's day.");
                        house[index] -= 2;
                    }
                    else if (house[index] - 2 < 0)
                    {
                        Console.WriteLine($"Place {index} already had Valentine's day.");
                        house[index] -= 2;
                    }
                    else
                    {
                        house[index] -= 2;
                    }

                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Cupid's last position was {index}.");

            bool isSuccessful = true;
            int count = 0;
            for (int i = 0; i < house.Length; i++)
            {
                if (house[i] > 0)
                {
                    count++;
                    isSuccessful = false;
                }
            }

            if (isSuccessful)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {count} places.");
            }
        }
    }
}