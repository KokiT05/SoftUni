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

            //Stack<int> waveOrcAttack = orcs[countOfWave];

            while (plates.Count > 0 && orcs.Count > 0)
            {
                Stack<int> waveOrcAttack = orcs[0];
                orcs.RemoveAt(0);

                int plate = plates.Peek();
                int orc = waveOrcAttack.Peek();
                bool plateInWhile = false;
                bool orcInWhile = false;
                while (plate > 0 && waveOrcAttack.Count > 0)
                {
                        orc = waveOrcAttack.Pop();
                        plate -= orc;
                    plateInWhile = true;
                }

                if (plate < 0)
                {
                    orc -=  orc + plate;
                }
                else if (plate == 0 && plateInWhile)
                {
                    plates.Dequeue();
                    orc = 0;
                }

                while (orc > 0 && plates.Count > 0)
                {
                    plate = plates.Dequeue();
                    //orc -= plate;
                    orcInWhile = true;
                }

                if (orc < 0)
                {
                    plate += orc;
                }
                else if (orc == 0 && orcInWhile)
                {
                    waveOrcAttack.Pop();
                    plate = 0;
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
                Console.WriteLine($"Orcs left: ");
                foreach (Stack<int> wavee in orcs)
                {
                    Console.Write($"{string.Join(", ", wavee)}");
                }
            }

            //Console.WriteLine("Hello, World!");
        }
    }
}
