using System;

namespace _07.Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstTupleInput = Console.ReadLine().Split(" ");
            string fullName = firstTupleInput[0] + " " + firstTupleInput[1];
            MyTuple<string, string> firstTuple =
                new MyTuple<string, string>(fullName, firstTupleInput[2]);

            string[] secondTupleInput = Console.ReadLine().Split(" ");
            MyTuple<string, int> secondTuple =
                new MyTuple<string, int>(secondTupleInput[0], int.Parse(secondTupleInput[1]));

            string[] thirdTupleInput = Console.ReadLine().Split(" ");
            MyTuple<int, double> thirdTuple =
                new MyTuple<int, double>(int.Parse(thirdTupleInput[0]), double.Parse(thirdTupleInput[1]));


            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
