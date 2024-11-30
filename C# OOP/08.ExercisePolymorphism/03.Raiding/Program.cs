namespace _03.Raiding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());

            while (heroes.Count < n)
            {
                string name = Console.ReadLine();
                string heroType = Console.ReadLine();

                BaseHero hero = CreateHero(name, heroType);

                if (hero == null)
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }

                heroes.Add(hero);

            }

            int bossPower = int.Parse(Console.ReadLine());

            foreach (BaseHero hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                bossPower -= hero.Power;
            }

            if (bossPower <= 0)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        public static BaseHero CreateHero(string name, string heroType)
        {
            BaseHero hero = null;
            if (heroType == nameof(Druid))
            {
                hero = new Druid(name);
            }
            else if (heroType == nameof(Paladin))
            {
                hero = new Paladin(name);
            }
            else if (heroType == nameof(Rogue))
            {
                hero = new Rogue(name);
            }
            else if (heroType == nameof(Warrior))
            {
                hero = new Warrior(name);
            }

            return hero;
        }
    }
}
