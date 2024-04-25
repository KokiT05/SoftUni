namespace _9.PokemonDon_tGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList();

            int sum = 0;
            while (pokemons.Any()) 
            {
                int index = int.Parse(Console.ReadLine());

                if (index < 0)
                {
                    int lastElement = pokemons.Last();
                    int removeElement = pokemons[0];
                    pokemons.RemoveAt(0);
                    pokemons.Insert(0, lastElement);

                    sum = sum + removeElement;
                    for (int i = 0; i < pokemons.Count; i++)
                    {
                        if (pokemons[i] <= removeElement)
                        {
                            pokemons[i] += removeElement;
                        }
                        else if (pokemons[i] > removeElement)
                        {
                            pokemons[i] -= removeElement;
                        }
                    }
                }
                else if (index >= pokemons.Count)
                {
                    int firstElements = pokemons.First();
                    int removeElement = pokemons[pokemons.Count - 1];
                    pokemons.RemoveAt(pokemons.Count - 1);
                    pokemons.Add(firstElements);

                    sum = sum + removeElement;
                    for (int i = 0; i < pokemons.Count; i++)
                    {
                        if (pokemons[i] <= removeElement)
                        {
                            pokemons[i] += removeElement;
                        }
                        else if (pokemons[i] > removeElement)
                        {
                            pokemons[i] -= removeElement;
                        }
                    }
                }
                else if (index < pokemons.Count)
                {
                    int currentElement = pokemons[index];
                    sum = sum + currentElement;
                    pokemons.RemoveAt(index);
                    for (int i = 0; i < pokemons.Count; i++)
                    {
                        if (pokemons[i] <= currentElement)
                        {
                            pokemons[i] += currentElement;
                        }
                        else if (pokemons[i] > currentElement)
                        {
                            pokemons[i] -= currentElement;
                        }
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}