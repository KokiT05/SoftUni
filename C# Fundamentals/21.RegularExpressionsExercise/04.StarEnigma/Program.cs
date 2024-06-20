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

            for (int i = 1; i <= countOfLines; i++)
            {
                string inputMessage = Console.ReadLine();
                pattern = @"[starSTAR]";
                regex = new Regex(pattern);

                MatchCollection match = regex.Matches(inputMessage);
                int countOfMatches = match.Count;

                StringBuilder decryptMessage = DecryptMessage(inputMessage, countOfMatches);

                pattern =
@"@(?<planeName>[A-Za-z]+)[^@:!\->]*:(?<population>[0-9]+)[^@:!\->]*\!(?<attackType>[A-Za-z])![^@:!\->]*->(?<soldier>[0-9]+)";
                regex = new Regex(pattern);
                MatchPlanet(planets, regex, decryptMessage);
            }

            planets = planets.OrderBy(planeName => planeName.Name).ToList();
            PrintPlanet(planets);
        }

        public static void PrintPlanet(List<Planet> planets)
        {
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

        public static void MatchPlanet(List<Planet> planets, Regex regex, StringBuilder decryptMessage)
        {
            Match decryptMatch = regex.Match(decryptMessage.ToString());

            if (decryptMatch.Success)
            {
                string planeName = decryptMatch.Groups["planeName"].Value;
                int population = int.Parse(decryptMatch.Groups["population"].Value);
                string attackType = decryptMatch.Groups["attackType"].Value;
                int soldierCount = int.Parse(decryptMatch.Groups["soldier"].Value);

                Planet planet = new Planet(planeName, population, attackType, soldierCount);
                planets.Add(planet);
            }
        }

        public static StringBuilder DecryptMessage(string message, int countOfMatch)
        {
            StringBuilder decryptMessage = new StringBuilder();
            decryptMessage.Clear();

            foreach (char character in message)
            {

                char decryptChar = (char)(character - countOfMatch);
                decryptMessage.Append(decryptChar);
            }

            return decryptMessage;
        }
    }
}