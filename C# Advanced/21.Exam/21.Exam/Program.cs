namespace _21.Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int wave = int.Parse(Console.ReadLine());
            Queue<int> plates = new Queue<int>(Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray());

            List<Stack<int>> orcs = new List<Stack<int>>();

            for (int i = 1; i <= wave; i++)
            {

                orcs.Add(new Stack<int>
                (Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray()));

                if (i % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(newPlate);
                }
            }

            while (plates.Count > 0 && orcs.Count > 1)
            {
                Stack<int> orcsWaveAttack = orcs[0];

                if (orcsWaveAttack.Count == 0 && orcs.Count != 1)
                {
                    orcs.RemoveAt(0);
                    orcsWaveAttack = orcs[0];
                }
                int plate = plates.Peek();

                //int orcValue = orcsWaveAttack.Peek();

                while (plate > 0 && orcsWaveAttack.Count > 0)
                {
                    int orcValue = orcsWaveAttack.Peek();
                    plate -= orcValue;
                    int currentOrc = orcsWaveAttack.Pop();


                    if (plate < 0)
                    {
                        currentOrc -= orcValue + plate;
                        plates.Dequeue();
                        orcsWaveAttack.Push(currentOrc);
                    }
                    else if (plate == 0)
                    {
                        plates.Dequeue();
                    }
                    currentOrc -= orcValue;
                    //orcValue = orcsWaveAttack.Peek();
                }
            }

            if (plates.Count > 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
            }

            if (orcs.Any(w => w.Count > 0))
            {
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs[0])}");
                //Console.WriteLine($"Orcs left: {string.Join(", ", orcs[0])}");
                //Console.WriteLine();
                //Console.WriteLine($"{string.Join(", ", orcs[])}");
            }
        }
    }
}
