namespace _01.WarmWinter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray());

            Queue<int> scarfs = new Queue<int>(Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray());

            List<int> sets = new List<int>();

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int hat = hats.Peek();
                int scarf = scarfs.Peek();

                if (hat > scarf)
                {
                    sets.Add(hat+scarf);
                    hats.Pop();
                    scarfs.Dequeue();
                }

                if (scarf > hat)
                {
                    hats.Pop();
                    continue;
                }

                if (scarf == hat)
                {
                    scarfs.Dequeue();
                    hat = hats.Pop();
                    hats.Push(hat+1);
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(' ', sets));
        }
    }
}
