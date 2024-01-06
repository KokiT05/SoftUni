using System;

namespace _09.YardGreening
{
    public class Program
    {
        static void Main(string[] args)
        {

            double priceForOneSqM = 7.61;

            double discount = 0.18;

            double squareMetersForLandscaping = double.Parse(Console.ReadLine());

            double totalDiscount = (priceForOneSqM * squareMetersForLandscaping) * discount;
            double totalSum = (priceForOneSqM * squareMetersForLandscaping) - totalDiscount;
            //На конзолата се отпечатват два реда:

            Console.WriteLine($"The final price is: {totalSum}");
            Console.WriteLine($"The discount is {totalDiscount}");
//•	"The final price is: {крайна цена на услугата} lv."
//•	"The discount is: {отстъпка} lv."

                
        }
    }
}
