using System;
using System.Collections.Generic;

namespace _5.BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<int> numbers = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList();

            int[] inputData = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            int specialBombNumber = inputData[0];
            int certainPower = inputData[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                int specialBombNumberIndex = numbers.IndexOf(specialBombNumber);

                if (specialBombNumberIndex == -1)
                {
                    break;
                }

                if (specialBombNumberIndex - certainPower >= 0)
                {
                    for (int j = specialBombNumberIndex - certainPower; j < specialBombNumberIndex; j++)
                    {
                        numbers[j] = 0;
                    }
                }
                else
                {
                    for (int j = 0; j < specialBombNumberIndex; j++)
                    {
                        numbers[j] = 0;
                    }
                }

                if (specialBombNumberIndex + certainPower < numbers.Count)
                {
                    for (int j = specialBombNumberIndex; j <= specialBombNumberIndex + certainPower; j++)
                    {
                        numbers[j] = 0;
                    }
                }
                else
                {
                    for (int j = specialBombNumberIndex; j < numbers.Count; j++)
                    {
                        numbers[j] = 0;
                    }
                }
            }

            Console.WriteLine(numbers.Sum());

        }
    }
}