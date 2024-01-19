using System;

namespace _07.TrekkingMania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double musalla = 0;
            double montBlanc = 0;
            double kilimanjaro = 0;
            double everest = 0;
            double k2 = 0;
            int numberOfPeopleInGroup = 0;
            int allPeople = 0;

            int numberOfGroups = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfGroups; i++)
            {
                numberOfPeopleInGroup = int.Parse(Console.ReadLine());

                if (numberOfPeopleInGroup >= 0 && numberOfPeopleInGroup <= 5)
                {
                    musalla += numberOfPeopleInGroup;
                }
                else if (numberOfPeopleInGroup >= 6 && numberOfPeopleInGroup <= 12)
                {
                    montBlanc += numberOfPeopleInGroup;
                }
                else if (numberOfPeopleInGroup >= 13 && numberOfPeopleInGroup <= 25)
                {
                    kilimanjaro += numberOfPeopleInGroup;
                }
                else if (numberOfPeopleInGroup >= 26 && numberOfPeopleInGroup <= 40)
                {
                    k2 += numberOfPeopleInGroup;
                }
                else if (numberOfPeopleInGroup >= 41)
                {
                    everest += numberOfPeopleInGroup;
                }

                allPeople = allPeople + numberOfPeopleInGroup;
            }
            Console.WriteLine($"{((musalla / allPeople) * 100):f2}%");
            Console.WriteLine($"{((montBlanc / allPeople) * 100):f2}%");
            Console.WriteLine($"{((kilimanjaro / allPeople) * 100):f2}%");
            Console.WriteLine($"{((k2 / allPeople) * 100):f2}%");
            Console.WriteLine($"{((everest / allPeople) * 100):f2}%");

        }
    }
}
