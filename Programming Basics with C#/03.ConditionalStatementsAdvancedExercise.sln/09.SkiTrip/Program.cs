using System;

namespace _09.SkiTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double roomForOnePerson = 18.00;
            double apartment = 25.00;
            double presidentApartment = 35.00;
            double discount = 0;
            double price = 0;
            double addToPrice = 0;

            int dayToStay = int.Parse(Console.ReadLine());
            string typeOfRoom = Console.ReadLine();
            string grade = Console.ReadLine();

            int overnigthStay = dayToStay - 1;

            if (typeOfRoom == "room for one person")
            {
                price = roomForOnePerson * overnigthStay;
            }
            else if (typeOfRoom == "apartment" && dayToStay < 10 && dayToStay > 0)
            {
                discount = 0.30;
                price = (apartment * overnigthStay);
            }
            else if (typeOfRoom == "apartment" && dayToStay >= 10 && dayToStay <= 15)
            {
                discount = 0.35;
                price = (apartment * overnigthStay);
            }
            else if (typeOfRoom == "apartment" && dayToStay > 15)
            {
                discount = 0.50;
                price = (apartment * overnigthStay);
            }
            else if (typeOfRoom == "president apartment" && dayToStay < 10 && dayToStay > 0)
            {
                discount = 0.10;
                price = presidentApartment * overnigthStay;
            }
            else if (typeOfRoom == "president apartment" && dayToStay >= 10 && dayToStay <= 15)
            {
                discount = 0.15;
                price = presidentApartment * overnigthStay;
            }
            else if (typeOfRoom == "president apartment" && dayToStay > 15)
            {
                discount = 0.20;
                price = presidentApartment * overnigthStay;
            }

            price = price - (price * discount);

            if (grade == "positive")
            {
                addToPrice = 0.25;
                price = price + (price * addToPrice);
            }
            else if (grade == "negative")
            {
                discount = 0.10;
                price = price - (price * discount);
            }

            Console.WriteLine($"{price:f2}");
        }
    }
}
