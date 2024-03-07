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
            bool isValidProduct = true;
            double sumOfCoins = 0;

            string coin = Console.ReadLine();

            while (coin != "Start")
            {
                if (coin != "2" && coin != "1" && coin != "0.5" && coin != "0.2" && coin != "0.1")
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }
                else
                {
                    sumOfCoins += double.Parse(coin);
                }

                coin = Console.ReadLine();
            }

            string product = Console.ReadLine();

            while (product != "End")
            {
                if (product == "Nuts")
                {
                    productPrice = 2;
                    isValidProduct = true;
                }
                else if (product == "Water")
                {
                    productPrice = 0.70;
                    isValidProduct = true;
                }
                else if (product == "Crisps")
                {
                    productPrice = 1.5;
                    isValidProduct = true;
                }
                else if (product == "Soda")
                {
                    productPrice = 0.80;
                    isValidProduct = true;
                }
                else if (product == "Coke")
                {
                    productPrice = 1;
                    isValidProduct = true;
                }
                else
                {
                    Console.WriteLine("Invalid product");
                    isValidProduct = false;
                }

                if (isValidProduct)
                {
                    if (sumOfCoins < productPrice)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        sumOfCoins -= productPrice;
                        Console.WriteLine($"Purchased {product.ToLower()}");
                    }
                }

                product = Console.ReadLine();
            }

            Console.WriteLine($"Change: {sumOfCoins:f2}");
        }
    }
}
