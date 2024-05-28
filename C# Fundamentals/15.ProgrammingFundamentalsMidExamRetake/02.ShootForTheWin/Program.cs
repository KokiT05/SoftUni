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

            int countOfTargets = 0;
            string command = Console.ReadLine();
            while (command != "End")
            {
                int index = int.Parse(command);

                if (index >= 0 && index < shotTargets.Length)
                {
                    int currentTargetValue = shotTargets[index];
                    if (currentTargetValue != -1)
                    {
                        countOfTargets++;
                        for (int i = 0; i < shotTargets.Length; i++)
                        {
                            if (shotTargets[i] <= currentTargetValue && shotTargets[i] != -1)
                            {
                                shotTargets[i] += currentTargetValue;
                            }
                            else if (shotTargets[i] != -1)
                            {
                                shotTargets[i] -= currentTargetValue;
                            }
                        }

                        shotTargets[index] = -1;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Shot targets: {countOfTargets} -> {string.Join(' ', shotTargets)}");
        }
    }
}