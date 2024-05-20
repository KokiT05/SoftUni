namespace _01.Counter_Strike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());

            bool isEnoughtEnergy = true;
            int wonBattleCount = 0;
            string command = Console.ReadLine();
            while (command != "End of battle")
            {
                int distance = int.Parse(command);

                if ((energy - distance) < 0)
                {
                    isEnoughtEnergy = false;
                    break;
                }
                else
                {
                    energy -= distance;
                    wonBattleCount++;

                    if (wonBattleCount % 3 == 0)
                    {
                        energy += wonBattleCount;
                    }
                }

                command = Console.ReadLine();
            }

            if (isEnoughtEnergy)
            {
                Console.WriteLine($"Won battles: {wonBattleCount}. Energy left: {energy}");
            }
            else
            {
                Console.WriteLine($"Not enough energy! Game ends with {wonBattleCount} won battles and {energy} energy.");
            }
        }
    }
}