namespace _03.SumPrimeNonPrime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            int counter = 0;
            bool isPrime = true;

            int primeSum = 0;
            int nonPrimeSum = 0;

            string command = Console.ReadLine();

            while (command != "stop") 
            {
                number = int.Parse(command);

                if (number >= 0)
                {
                    counter = 0;

                    for (int i = 1; i <= 10; i++)
                    {
                        if (number % i == 0)
                        {
                            counter++;

                        }
                    }

                    if (number == 0)
                    {
                        isPrime = true;
                    }
                    else if (counter <= 2)
                    {
                        isPrime = true;
                    }
                    else if (counter > 2)
                    {
                        isPrime = false;
                    }

                    if (isPrime)
                    {
                        primeSum += number;
                    }
                    else
                    {
                        nonPrimeSum += number;
                    }
                }
                else
                {
                    Console.WriteLine("Number is negative.");
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
        }
    }
}