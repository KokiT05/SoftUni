namespace _03.Raiding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Heroes heroes = new Heroes();
            BaseHero hero = null;
            List<BaseHero> raidGroup = new List<BaseHero>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string heroType = Console.ReadLine();

                if (!Enum.TryParse(heroType, out heroes))
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }

                if (heroType == "Druid")
                {
                    hero = new Druid(name);
                }
                else if (heroType == "Paladin")
                {
                    hero = new Paladin(name);
                }
                else if (heroType == "Rogue")
                {
                    hero = new Rogue(name);
                }
                else if (heroType == "Warrior")
                {
                    hero = new Warrior(name);
                }

                raidGroup.Add(hero);
            }

            int bossPower = int.Parse(Console.ReadLine());
            int totalHeroesPower = 0;

            foreach (BaseHero currentHero in raidGroup)
            {
                Console.WriteLine(currentHero.CastAbility());
                totalHeroesPower += currentHero.Power;
            }

            if (totalHeroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
