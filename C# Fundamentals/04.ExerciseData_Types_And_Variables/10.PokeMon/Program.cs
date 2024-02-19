using System;

namespace _10.PokeMon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int targetCounter = 0;
            int currentPokePower = 0;

            // poke power
            int N = int.Parse(Console.ReadLine());
            currentPokePower = N;
            // distance
            int M = int.Parse(Console.ReadLine());
            // exhaustion factor
            int Y = int.Parse(Console.ReadLine());

            while (currentPokePower >= M)
            {
                currentPokePower -= M;
                targetCounter++;

                if (((N / 2) == currentPokePower) && (N != 0 && Y != 0))
                {
                    currentPokePower = currentPokePower / Y;
                }
            }

            Console.WriteLine(currentPokePower);
            Console.WriteLine(targetCounter);
        }
    }
}
