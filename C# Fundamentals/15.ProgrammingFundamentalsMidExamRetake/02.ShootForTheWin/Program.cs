namespace _02.ShootForTheWin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] shotTargets = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            string command = Console.ReadLine();
            while (command != "End")
            {
                int index = int.Parse(command);

                if (index >= 0 && index < shotTargets.Length)
                {
                    shotTargets[index] = shotTargets[index] - 1;
                }

                for (int i = 0; i < shotTargets.Length; i++)
                {
                    if (shotTargets[index] < shotTargets[i])
                    {
                        shotTargets[i] -= shotTargets[index];
                    }
                    else if (shotTargets[index] >= shotTargets[i])
                    {
                        shotTargets[i] += shotTargets[index];
                    }
                }

                command = Console.ReadLine();
            }
        }
    }
}