using System.Text.RegularExpressions;
using System.Text;

namespace _04.StarEnigma
{
    class Planet
    {
        public Planet(string name, int population, string attackType, int soldierCount)
        {
            this.Name = name;
            this.Population = population;
            this.AttackType = attackType;
            this.SoldierCount = soldierCount;
        }

        public string Name { get; set; }

        public int Population { get; set; }

        public string AttackType { get; set; }

        public int SoldierCount { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfLines = int.Parse(Console.ReadLine());

            List<Planet> planets = new List<Planet>();

            string pattern = @"[starSTAR]";
            Regex regex = new Regex(pattern);

            StringBuilder decryptMessage = new StringBuilder();
            string planeName = string.Empty;
            int population = 0;
            string attackType = string.Empty;
            int soldierCount = 0;

            for (int i = 1; i <= countOfLines; i++)
            {
                string inputMessage = Console.ReadLine();
                decryptMessage.Clear();
                pattern = @"[starSTAR]";
                regex = new Regex(pattern);

                MatchCollection match = regex.Matches(inputMessage);
                int countOfMatches = match.Count;

                foreach (char character in inputMessage)
                {
                    char decryptChar = (char)(character - countOfMatches);
                    decryptMessage.Append(decryptChar);
                }

                pattern =
            @"@(?<planeName>[A-Za-z]+)\w?:(?<population>[0-9]+)!(?<attackType>[A-Za-z])!->(?<soldier>[0-9]+)";
                regex = new Regex(pattern);
                Match decryptMatch = regex.Match(decryptMessage.ToString());

                if (decryptMatch.Success)
                {
                    planeName = decryptMatch.Groups["planeName"].Value;
                    population = int.Parse(decryptMatch.Groups["population"].Value);
                    attackType = decryptMatch.Groups["attackType"].Value;
                    soldierCount = int.Parse(decryptMatch.Groups["soldier"].Value);

                    Planet planet = new Planet(planeName, population, attackType, soldierCount);
                    planets.Add(planet);
                }
            }

            int countofAttackType = planets.Where(attackType => attackType.AttackType == "A").Count();

            Console.WriteLine($"Attacked planets: {countofAttackType}");
            foreach (Planet planet in planets.Where(attackType => attackType.AttackType == "A"))
            {
                Console.WriteLine($"-> {planet.Name}");
            }

            countofAttackType = planets.Where(attackType => attackType.AttackType == "D").Count();

            Console.WriteLine($"Destroyed planets: {countofAttackType}");
            foreach (Planet planet in planets.Where(attackType => attackType.AttackType == "D"))
            {
                Console.WriteLine($"-> {planet.Name}");
            }
        }
    }
}