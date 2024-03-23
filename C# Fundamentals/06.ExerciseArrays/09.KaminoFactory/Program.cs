using System;
using System.Data.SqlTypes;
using System.Reflection.Metadata;
using System.Security;

namespace _09.KaminoFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            int bestCoun = 0;
            int bestIndex = 0;
            int bestCounter = 0;
            int bestSum = 0;
            string bestSequence = string.Empty;

            int counter = 0;
            while (input != "Clone them!")
            {
                string sequence = input.Replace("!", "");
                string[] dnaParts = sequence.Split('0', StringSplitOptions.RemoveEmptyEntries);

                int count = 0;
                int sum = 0;
                int beginIndex = 0;
                string currentSequence = string.Empty;
                counter++;
                foreach (string dnaPart in dnaParts)
                {
                    if (dnaPart.Length > count)
                    {
                        count = dnaPart.Length;
                        currentSequence = dnaPart;
                    }
                    sum += dnaPart.Length;
                }

                beginIndex = sequence.IndexOf(currentSequence);

                if (count > bestCoun || 
                    (count == bestCoun && beginIndex < bestIndex) ||
                    (count == bestCoun && beginIndex == bestIndex && sum > bestSum) ||
                    counter == 1)
                {
                    bestCoun = count;
                    bestIndex = beginIndex;
                    bestSum = sum;
                    bestCounter = counter;
                    bestSequence = sequence;
                }

                input = Console.ReadLine();
            }

            char[] result = bestSequence.ToCharArray();

            Console.WriteLine($"Best DNA sample {bestCounter} with sum: {bestSum}.");
            Console.WriteLine($"{string.Join(" ", result)}");

            //int size = int.Parse(Console.ReadLine());

            //string input = string.Empty;
            //int bestCount = 0;
            //int bestCounter = 0;
            //int counter = 0;
            //int bestBeginIndex = 0;
            //int bestSum = 0;
            //string bestSequence = string.Empty;

            //while ((input = Console.ReadLine()) != "Clone them!")
            //{
            //    string sequences = input.Replace("!", "");

            //    string[] dnaParts = sequences.Split("0", 
            //                        StringSplitOptions.RemoveEmptyEntries);

            //    int count = 0;
            //    int sum = 0;
            //    string bestSubSequence = string.Empty;
            //    counter++;

            //    foreach (string dnaPart in dnaParts)
            //    {
            //        if (dnaPart.Length > count)
            //        {
            //            count = dnaPart.Length;
            //            bestSubSequence = dnaPart;
            //        }
            //        sum += dnaPart.Length;
            //    }

            //    int beginIndex = sequences.IndexOf(bestSubSequence);

            //    if (count > bestCount || 
            //        (count == bestCount && beginIndex < bestBeginIndex) ||
            //        (count == bestCount && beginIndex == bestBeginIndex && sum > bestSum) ||
            //        counter == 1) 
            //    {
            //        bestCount = count;
            //        bestBeginIndex = beginIndex;
            //        bestSum = sum;
            //        bestSequence = sequences;
            //        bestCounter = counter;
            //    }
            //}

            //char[] result = bestSequence.ToCharArray();

            //Console.WriteLine($"Best DNA sample {bestCounter} with sum: {bestSum}.");
            //Console.WriteLine($"{string.Join(" ", result)}");
        }
    }
}
