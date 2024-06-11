namespace _04.Snowwhite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> drawfs = new Dictionary<string, int>();

            string inputLine = Console.ReadLine();

            while (inputLine != "Once upon a time")
            {
                string[] inportArr = inputLine.Split(" <:> ");
                string name = inportArr[0];
                string hairColor = inportArr[1];
                int physics = int.Parse(inportArr[2]);

                string key = $"({hairColor}) {name}";

                if (!drawfs.ContainsKey(key))
                {
                    drawfs.Add(key, 0);
                }

                if (drawfs[key] < physics)
                {
                    drawfs[key] = physics;
                }

                inputLine = Console.ReadLine();
            }

            foreach (var drawf in drawfs.OrderByDescending(kvp => kvp.Value)
            .ThenByDescending
            (c => drawfs.Where(kvp => kvp.Key.Split(")")[0] == c.Key.Split(")")[0]).Count()))
            {
                Console.WriteLine($"{drawf.Key} <-> {drawf.Value}");
            }
        }
    }
}