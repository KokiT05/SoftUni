using System;
using System.Net;
using System.Runtime.CompilerServices;

namespace _05.Salary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double facebookA_Fine = 150;
            double instagramA_Fine = 100;
            double redditA_Fine = 50;

            string websiteName = string.Empty;
            bool flag = true;

            int numberOfOpenTabs = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());


            for (int i = 1; i <= numberOfOpenTabs; i++)
            {
                websiteName = Console.ReadLine();

                websiteName = websiteName.ToLower();

                if (websiteName == "facebook")
                {
                    salary = salary - facebookA_Fine;
                }
                else if (websiteName == "instagram")
                {
                    salary = salary - instagramA_Fine;
                }
                else if (websiteName == "reddit")
                {
                    salary = salary - redditA_Fine;
                }

                if (salary <= 0)
                {
                    flag = false;
                    break;
                }
            }

            if (!flag)
            {
                Console.WriteLine("You have lost your salary.");
            }
            else
            {
                Console.WriteLine(salary);
            }
        }
    }
}
