namespace _2.SumEvensInRange
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "show")
                {
                    int result = SumEvenNumbersAsync();
                    Console.WriteLine(result);
                }
            }
        }

        public static int SumEvenNumbersAsync()
        {
            return Task.Run(() =>
            {
                int sum = 0;
                for (int i = 1; i <= 1000; i++)
                {
                    if (i % 2 == 0)
                    {
                        sum += i;
                    }
                }

                return sum;
            }).Result;

        }
    }
}
