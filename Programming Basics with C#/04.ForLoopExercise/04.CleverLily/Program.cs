using System;

namespace _04.CleverLily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int toys = 0;
            int money = 10;
            double totalMoney = 0;
            int countEvenAge = 0;
            double totalMoneyForToys = 0;

            int age = int.Parse(Console.ReadLine());
            double priceOfWashingMachine = double.Parse(Console.ReadLine());
            double pricePerToy = double.Parse(Console.ReadLine());

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 ==0)
                {
                    totalMoney += money;
                    money = money + 10;
                    countEvenAge++;
                }
                else
                {
                    toys += 1;
                }
            }

            totalMoney = totalMoney - countEvenAge;
            totalMoneyForToys = toys * pricePerToy;
            totalMoney = totalMoney + totalMoneyForToys;

            double result = Math.Abs(totalMoney - priceOfWashingMachine);
            if (totalMoney >= priceOfWashingMachine)
            {
                Console.WriteLine($"Yes, {result:f2}");
            }
            else
            {
                Console.WriteLine($"No! {result:f2}");
            }
        }
    }
}
