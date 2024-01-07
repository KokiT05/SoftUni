using System;

namespace _08.BasketballEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            decimal annualFee = decimal.Parse(Console.ReadLine());

            decimal basketballShoes = annualFee * 0.60M;
            decimal basketballGrear = basketballShoes * 0.80M;
            decimal basketballBall = basketballGrear / 4M;
            decimal basketballAccessories = basketballBall / 5;

            decimal totalPrice = basketballShoes + basketballGrear
                + basketballBall + basketballAccessories + annualFee;

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
