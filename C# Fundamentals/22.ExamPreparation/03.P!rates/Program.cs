namespace _03.P_rates
{
    internal class Program
    {
        class City
        {
            public City(string name, int population, double gold)
            {
                this.Name = name;
                this.Population = population;
                this.Gold = gold;
            }

            public string Name { get; set; }

            public int Population { get; set; }

            public double Gold { get; set; }
        }

        static void Main(string[] args)
        {
            Dictionary<string, City> cities = new Dictionary<string, City>();

            string town = string.Empty;
            int population = 0;
            double gold = 0.0D;

            string command = Console.ReadLine();
            while (command.ToLower() != "sail")
            {
                string[] commandArg = command.Split("||");
                town = commandArg[0];
                population = int.Parse(commandArg[1]);
                gold = double.Parse(commandArg[2]);

                City city = new City(town, population, gold);

                if (cities.ContainsKey(town) == false)
                {
                    cities.Add(town, city);
                }
                else 
                {
                    cities[town].Population += population;
                    cities[town].Gold += gold;
                }

                command = Console.ReadLine();
            }

            string events = Console.ReadLine();
            while (events.ToLower() != "end")
            {
                string[] eventsData = events.Split("=>");
                string @event = eventsData[0];
                town = eventsData[1];

                if (@event.ToLower() == "plunder" && cities.ContainsKey(town))
                {
                    population = int.Parse(eventsData[2]);
                    gold = double.Parse(eventsData[3]);
                    Console.
                    WriteLine($"{town} plundered! {gold} gold stolen, {population} citizens killed.");

                    if (cities[town].Population - population == 0 ||
                        cities[town].Gold - gold == 0)
                    {
                        Console.WriteLine($"{town} has been wiped off the map!");
                        cities.Remove(town);
                    }
                    else
                    {
                        cities[town].Population = cities[town].Population - population;
                        cities[town].Gold = cities[town].Gold - gold;
                    }
                }
                else if (@event.ToLower() == "prosper" && cities.ContainsKey(town))
                {
                    gold = double.Parse(eventsData[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine($"Gold added cannot be a negative number!");
                    }
                    else
                    {
                        cities[town].Gold += gold;
                        Console.
                        WriteLine
                        ($"{gold} gold added to the city treasury. {town} now has {cities[town].Gold} gold.");
                    }
                }

                events = Console.ReadLine();
            }

            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (string city in cities.Keys)
                {
                    Console.WriteLine($"{city} -> Population: {cities[city].Population} citizens, Gold: {cities[city].Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}