using System;

namespace _06.ExerciseArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfWagons = int.Parse(Console.ReadLine());

            int[] wagons = new int[countOfWagons];
            int currentWagon = 0;
            for (int i = 0; i < countOfWagons; i++)
            {
                currentWagon = int.Parse(Console.ReadLine());
                wagons[i] = currentWagon;
            }

            int sumOfPeople = 0;
            for (int i = 0; i < wagons.Length; i++)
            {
                sumOfPeople += wagons[i];
            }

            Console.WriteLine(string.Join(' ', wagons));
            Console.WriteLine(sumOfPeople);
        }
    }
}
