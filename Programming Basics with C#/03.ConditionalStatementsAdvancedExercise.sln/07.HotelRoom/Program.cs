using System;

namespace _07.HotelRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double discount = 0;
            double discountApartment = 0;
            double priceStudio = 0;
            double priceApartment = 0;

            string month = Console.ReadLine();
            int numberOfOvernightStays = int.Parse(Console.ReadLine());

            month = month.ToLower();

            if (month == "may" ||  month == "october")
            {
                priceApartment = 65;
                priceStudio = 50;
                if (numberOfOvernightStays > 7 && numberOfOvernightStays <= 14)
                {
                    discount = 0.05;

                }
                else if (numberOfOvernightStays > 14)
                {
                    discount = 0.30;
                    
                }
            }
            else if (month == "june" || month == "september")
            {
                priceStudio = 75.20;
                priceApartment = 68.70;
                if (numberOfOvernightStays > 14)
                {
                    discount = 0.20;
                }
            }
            else if (month == "july" || month == "august")
            {
                priceApartment = 77;
                priceStudio = 76;
            }

            if (numberOfOvernightStays > 14)
            {
                discountApartment = 0.10;
            }

            priceStudio = (priceStudio - (priceStudio * discount)) * numberOfOvernightStays;
            priceApartment = (priceApartment - (priceApartment * discountApartment)) * numberOfOvernightStays;

            Console.WriteLine($"Apartment: {priceApartment:f2} lv.");
            Console.WriteLine($"Studio: {priceStudio:f2} lv.");
        }
    }
}
