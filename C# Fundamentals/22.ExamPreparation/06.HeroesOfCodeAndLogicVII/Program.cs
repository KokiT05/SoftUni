namespace _06.HeroesOfCodeAndLogicVII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> heroes = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string[] heroData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string heroName = heroData[0];

                double hitPoint = double.Parse(heroData[1]);
                double manaPoint = double.Parse(heroData[2]);

                if (hitPoint <= 100 && manaPoint <= 200 && (heroes.ContainsKey(heroName) == false))
                {
                    heroes.Add(heroName, new List<double>() { hitPoint, manaPoint });
                }

            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputData = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string command = inputData[0];
                string heroName = inputData[1];

                switch (command)
                {
                    case "CastSpell":
                        double MPneeded = double.Parse(inputData[2]);
                        string spellName = inputData[3];
                        CastSpell(heroes, heroName, MPneeded, spellName);
                        break;
                    case "TakeDamage":
                        double damage = double.Parse(inputData[2]);
                        string attacker = inputData[3];
                        TakeDamage(heroes, heroName, damage, attacker);
                        break;
                    case "Recharge":
                        double amountMP = double.Parse(inputData[2]);
                        Recharge(heroes, heroName, amountMP);
                        break;
                    case "Heal":
                        double amountHP = double.Parse(inputData[2]);
                        Heal(heroes, heroName, amountHP);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            foreach (KeyValuePair<string, List<double>> hero in heroes)
            {
                Console.WriteLine($"{hero.Key}");
                Console.WriteLine($"  HP: {hero.Value[0]}");
                Console.WriteLine($"  MP: {hero.Value[1]}");
            }
        }

        static void CastSpell
        (Dictionary<string, List<double>> heroes,
        string heroName,
        double MPneeded,
        string spellName)
        {
            if (ContainsHero(heroes, heroName) && heroes[heroName][1] >= MPneeded)
            {
                heroes[heroName][1] -= MPneeded;
                Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName][1]} MP!");
            }
            else
            {
                Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
            }
        }

        static void TakeDamage
        (Dictionary<string, List<double>> heroes,
        string heroName,
        double damage,
        string attacker)
        {
            if (ContainsHero(heroes, heroName))
            {
                heroes[heroName][0] -= damage;
                if (heroes[heroName][0] <= 0)
                {
                    Console.WriteLine($"{heroName} has been killed by {attacker}!");
                    heroes.Remove(heroName);
                }
                else
                {

                    Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName][0]} HP left!");
                }
            }
        }

        static void Recharge
        (Dictionary<string, List<double>> heroes,
        string heroName,
        double amountMP)
        {


            if (ContainsHero(heroes, heroName))
            {
                if (heroes[heroName][1] + amountMP > 200)
                {
                    Console.WriteLine($"{heroName} recharged for {200 - heroes[heroName][1]} MP!");
                    heroes[heroName][1] = 200;
                }
                else
                {
                    heroes[heroName][1] += amountMP;
                    Console.WriteLine($"{heroName} recharged for {amountMP} MP!");
                }
            }
        }

        static void Heal
        (Dictionary<string, List<double>> heroes,
        string heroName,
        double amountHP)
        {
            if (ContainsHero(heroes, heroName))
            {
                if (heroes[heroName][0] + amountHP > 100)
                {
                    Console.WriteLine($"{heroName} healed for {100 - heroes[heroName][0]} HP!");
                    heroes[heroName][0] = 100;
                }
                else
                {
                    heroes[heroName][0] += amountHP;
                    Console.WriteLine($"{heroName} healed for {amountHP} HP!");
                }
            }
        }

        static bool ContainsHero(Dictionary<string, List<double>> heroes, string heroName)
        {
            if (heroes.ContainsKey(heroName))
            {
                return true;
            }

            return false;
        }
    }
}