namespace _3.SumEvensInBackground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long sum = 0;
            Task.Run(() =>
            {
                for (int i = 1; i <= 1000000000; i++)
                {
                    if (i % 2 == 0)
                    {
                        sum += i;
                    }
                }
            });

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "show")
                {
                    Console.WriteLine(sum);
                }
                else if (command == "exit")
                {
                    return;
                }
            }
        }
    }
}
