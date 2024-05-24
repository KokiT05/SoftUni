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

<<<<<<< HEAD
=======
            int countOfTargets = 0;
>>>>>>> 0713a739e52871eddf77b16f789098c4bb55c8e6
            string command = Console.ReadLine();
            while (command != "End")
            {
                int index = int.Parse(command);

                if (index >= 0 && index < shotTargets.Length)
                {
<<<<<<< HEAD
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
=======
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
>>>>>>> 0713a739e52871eddf77b16f789098c4bb55c8e6
                    }
                }

                command = Console.ReadLine();
            }
<<<<<<< HEAD
=======

            Console.WriteLine($"Shot targets: {countOfTargets} -> {string.Join(' ', shotTargets)}");
>>>>>>> 0713a739e52871eddf77b16f789098c4bb55c8e6
        }
    }
}