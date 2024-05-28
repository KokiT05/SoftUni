namespace _02.A_MinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> resourceQuantity = new Dictionary<string, double>();

            string resource = Console.ReadLine();
            while (resource != "stop")
            {
                double quantity = double.Parse(Console.ReadLine());
                if (resourceQuantity.ContainsKey(resource))
                {
                    resourceQuantity[resource] += quantity;
                }
                else
                {
                    resourceQuantity.Add(resource, quantity);
                }

                resource = Console.ReadLine();
            }

            foreach (KeyValuePair<string, double> item in resourceQuantity)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}