using System;
using System.Numerics;

namespace _9.PadawanEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceOfLightsaber = double.Parse(Console.ReadLine());
            double priceOfRobe = double.Parse(Console.ReadLine());
            double priceOfBelt = double.Parse(Console.ReadLine());

            double moreLightsaber = Math.Ceiling(countOfStudents * 0.10);
            int freeBelts = countOfStudents / 6;
            double freeBeltsPrice = freeBelts * priceOfBelt;

            double totalPriceOfLightsabers = (countOfStudents * priceOfLightsaber);
            totalPriceOfLightsabers = totalPriceOfLightsabers + (priceOfLightsaber * moreLightsaber);

            double totalPriceOfRobes = priceOfRobe * countOfStudents;
            double totalPriceOfBelts = priceOfBelt * countOfStudents;
            totalPriceOfBelts = totalPriceOfBelts - freeBeltsPrice;

            double totalPriceForEquipment = totalPriceOfLightsabers + 
                                            totalPriceOfRobes + 
                                            totalPriceOfBelts;

            if (amountOfMoney >= totalPriceForEquipment)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPriceForEquipment:f2}lv.");
            }
            else
            {
                double needMoney = totalPriceForEquipment - amountOfMoney;
                Console.WriteLine($"Ivan Cho will need {needMoney:f2}lv more.");
            }
        }
    }
}
