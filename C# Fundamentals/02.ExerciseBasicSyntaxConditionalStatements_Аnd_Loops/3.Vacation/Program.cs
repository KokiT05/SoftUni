using System;
using System.Security;

namespace _3.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double currentPriceOnePerson = 0;
            double discount = 0;

            int groupOfPeople = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            typeOfGroup = typeOfGroup.ToLower();

            string dayOfWeek = Console.ReadLine();
            dayOfWeek = dayOfWeek.ToLower();

            if (dayOfWeek == "friday")
            {
                if (typeOfGroup == "students")
                {
                    currentPriceOnePerson = 8.45;
                }
                else if (typeOfGroup == "business")
                {
                    currentPriceOnePerson = 10.90;
                }
                else if (typeOfGroup == "regular")
                {
                    currentPriceOnePerson = 15;
                }
            }
            else if (dayOfWeek == "saturday")
            {
                if (typeOfGroup == "students")
                {
                    currentPriceOnePerson = 9.80;
                }
                else if (typeOfGroup == "business")
                {
                    currentPriceOnePerson = 15.60;
                }
                else if (typeOfGroup == "regular")
                {
                    currentPriceOnePerson = 20;
                }
            }
            else if (dayOfWeek == "sunday")
            {
                if (typeOfGroup == "students")
                {
                    currentPriceOnePerson = 10.46;
                }
                else if (typeOfGroup == "business")
                {
                    currentPriceOnePerson = 16;
                }
                else if (typeOfGroup == "regular")
                {
                    currentPriceOnePerson = 22.50;
                }
            }

            if (typeOfGroup == "students" && groupOfPeople >= 30)
            {
                discount = 0.15;
            }
            else if (typeOfGroup == "business" && groupOfPeople >= 100)
            {
                discount = Math.Round(10.0 / groupOfPeople, 2);
            }
            else if (typeOfGroup == "regular" && (groupOfPeople >= 10 && groupOfPeople <= 20))
            {
                discount = 0.05;
            }

            double totalPrice = (currentPriceOnePerson * groupOfPeople);
            double resultOfDiscount = discount * totalPrice;
            totalPrice = totalPrice - resultOfDiscount;

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
