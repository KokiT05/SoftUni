using System.Formats.Asn1;

namespace _05.SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isSpecial = false;
            int number = 0;

            int unit = 0;

            int n = int.Parse(Console.ReadLine());

            for (int i = 1111; i <= 9999; i++)
            {
                number = i;
                for (int j = 0; j < 4; j++)
                {

                    unit = number % 10;
                    number = number / 10;

                    if (unit != 0)
                    {
                        if (n % unit == 0)
                        {
                            isSpecial = true;
                        }
                        else
                        {
                            isSpecial = false;
                            break;
                        }
                    }
                    else
                    {
                        isSpecial = false;
                        break;
                    }
                }

                if (isSpecial)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}