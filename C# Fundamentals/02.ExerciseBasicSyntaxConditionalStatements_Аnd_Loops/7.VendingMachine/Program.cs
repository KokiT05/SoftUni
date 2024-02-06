using System;

namespace _7.VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //double priceNuts = 2;
            //double priceWater = 0.70;
            //double priceCrisps = 1.5;
            //double priceSoda = 0.80;
            //double priceCoke = 1.0;
            double productPrice = 0;

            double sumOfCoins = 0;

            string coin = Console.ReadLine();

            while (coin != "Start")
            {
                if (coin != "2" && coin != "1" && coin != "0,5" && coin != "0,2" && coin != "0,1")
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }
                else
                {
                    sumOfCoins += double.Parse(coin);
                }

                coin = Console.ReadLine();
            }

            Console.WriteLine(sumOfCoins);

            string product = Console.ReadLine();

            while (product != "End")
            {
                if (product == "Nuts")
                {
                    productPrice = 2;
                }
                else if (product == "Water")
                {
                    productPrice = 0.70;
                }
                else if (product == "Crisps")
                {
                    productPrice = 1.5;
                }
                else if (product == "Soda")
                {
                    productPrice = 0.80;
                }
                else if (product == "Coke")
                {
                    productPrice = 1;
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }

                if (sumOfCoins < productPrice)
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                else
                {
                    sumOfCoins -= productPrice;
                    Console.WriteLine($"Purchased {product}");
                }

                product = Console.ReadLine();
            }

            Console.WriteLine($"Change: {sumOfCoins}");
        }
    }
}
