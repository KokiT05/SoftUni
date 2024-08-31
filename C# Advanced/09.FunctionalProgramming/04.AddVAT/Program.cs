namespace _04.AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Func<double, double> priceVAT = price => price += price * 0.20;

            //double[] prices = Console.ReadLine()
            //                        .Split(", ")
            //                        .Select(p => double.Parse(p))
            //                        .Select(priceVAT)
            //                        .ToArray();

            //foreach (double price in prices)
            //{
            //    Console.WriteLine($"{price:f2}");
            //}

            //decimal[] prices = Console.ReadLine()
            //                        .Split(", ")
            //                        .Select(p => decimal.Parse(p))
            //                        .Select(p => p += p * 0.20M)
            //                        .ToArray();

            //foreach (double price in prices)
            //{
            //    Console.WriteLine($"{price:f2}");
            //}

            decimal[] numbers = Console.ReadLine()
                                        .Split(", ")
                                        .Select(decimal.Parse)
                                        .ToArray();

            numbers = SelectDecinal(numbers, n => n + (n * 0.20M));

            foreach (double price in numbers)
            {
                Console.WriteLine($"{price:f2}");
            }
        }

        static decimal[] SelectDecinal(decimal[] array, Func<decimal, decimal> transformer)
        {
            decimal[] newArray = new decimal[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = transformer(array[i]);
            }

            return newArray;
        }
    }
}
