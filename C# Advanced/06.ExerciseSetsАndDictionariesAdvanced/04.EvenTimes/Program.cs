namespace _04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> numbersCount = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string number = Console.ReadLine();

                if (!numbersCount.ContainsKey(number))
                {
                    numbersCount.Add(number, 0);
                }

                numbersCount[number]++;
            }

            string result = numbersCount
                            .Keys.
                            First(v => numbersCount[v] % 2 == 0);

            Console.WriteLine(result);
        }
    }
}
