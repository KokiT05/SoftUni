namespace _05.DragonArmy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfDragons = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, double[]>> dragonsInfo =
                new Dictionary<string, Dictionary<string, double[]>>();

            for (int i = 1; i <= numberOfDragons; i++)
            {
                string[] inputArr = Console.ReadLine().Split(' ');
                string type = inputArr[0];
                string name = inputArr[1];
                double damage = 
                inputArr[2] == "null" || inputArr[2] == "0" ? 45 : double.Parse(inputArr[2]);
                double health =
                inputArr[3] == "null" || inputArr[3] == "0" ? 250 : double.Parse(inputArr[3]);
                double armor =
                inputArr[4] == "null" || inputArr[4] == "0" ? 10 : double.Parse(inputArr[4]);

                if (dragonsInfo.ContainsKey(type) == false)
                {
                    dragonsInfo.Add
                    (type, new Dictionary<string, double[]> 
                    { { name, new double[3] { damage, health, armor } } });
                }
                else if (dragonsInfo[type].ContainsKey(name) == false)
                {
                    dragonsInfo[type].Add(name, new double[3] { damage, health, armor });
                }
                else
                {
                    double[] newStats = new double[3] {damage, health, armor};
                    dragonsInfo[type][name] = newStats;
                }
            }

            foreach (string type in dragonsInfo.Keys)
            {
                Console.Write($"{type}::");
                Console.Write($"({dragonsInfo[type].Values.Average(v => v[0]):f2}/");
                Console.Write($"{dragonsInfo[type].Values.Average(v => v[1]):f2}/");
                Console.Write($"{dragonsInfo[type].Values.Average(v => v[2]):f2})\n");

                foreach (KeyValuePair<string, double[]> dragon in 
                    dragonsInfo[type].OrderBy(k => k.Key))
                {
                    Console.Write($"-{dragon.Key} -> ");
                    Console.Write($"damage: { dragon.Value[0]}, ");
                    Console.Write($"health: {dragon.Value[1]}, ");
                    Console.Write($"armor: {dragon.Value[2]}\n");
                }
            }
        }
    }
}