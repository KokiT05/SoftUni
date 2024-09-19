namespace _09.PokemonTrainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> coaches = new Dictionary<string, Trainer>();

            string[] splitInput = Console.ReadLine().Split(" ");
            while (splitInput[0].ToLower() != "tournament")
            {
                string trainerName = splitInput[0];
                string pokemonName = splitInput[1];
                string pokemonElement = splitInput[2];
                int health = int.Parse(splitInput[3]);

                Pokenmon pokenmon = new Pokenmon(pokemonName, pokemonElement, health);
                Trainer trainer = new Trainer(trainerName);
                if (!coaches.ContainsKey(trainerName))
                {
                    coaches.Add(trainerName, trainer);
                }

                coaches[trainerName].AddPokemon(pokenmon);

                splitInput = Console.ReadLine().Split(" ");
            }

            string element = Console.ReadLine();
            while (element.ToLower() != "end")
            {
                foreach (Trainer trainer in coaches.Values)
                {
                    if (trainer.Pokenmons.Any(p => p.Element == element))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        trainer.Pokenmons.Select(p => p.Health - 10);
                    }
                }

                element = Console.ReadLine();
            }

            foreach (Trainer trainer in coaches.Values.OrderByDescending(p => p.NumberOfBadges))
            {
                trainer.Pokenmons = trainer.Pokenmons.Where(p => p.Health >= 0).ToList();
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokenmons.Count}");
            }
        }
    }
}
