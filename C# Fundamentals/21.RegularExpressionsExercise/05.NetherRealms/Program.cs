using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    class Demon
    {
        public Demon(string name, int health, double damage)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
        }

        public string Name { get; set; }

        public int Health { get; set; }

        public double Damage { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Health} health, {Damage:f2} damage";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Demon> allDemons = new List<Demon>();

            string pattern = @"[-+]?[0-9]+\.?[0-9]*";

            Regex regex = new Regex(pattern);

            string[] input = Console.ReadLine().Split(new[] { ',', ' '}, StringSplitOptions.RemoveEmptyEntries);

            foreach (string demon in input) 
            {
                string filter = "0123456789+-*/.";

                int health = demon.Where(ch => !filter.Contains(ch)).Sum(ch => ch);
                double damage = CalculateDamage(regex, demon);
                string name = demon;
                Demon currentDemon = new Demon(name, health, damage);
                allDemons.Add(currentDemon);
            }

            allDemons = allDemons.OrderBy(d => d.Name).ToList();
            foreach (Demon demon in allDemons)
            {
                Console.WriteLine(demon);
            }
        }

        public static double CalculateDamage(Regex regex, string demon)
        {
            MatchCollection matchCollection = regex.Matches(demon);

            double damage = 0;
            foreach (Match match in matchCollection)
            {
                damage += double.Parse(match.Value);
            }

            foreach (char oneChar in demon)
            {
                if (oneChar == '*')
                {
                    damage = damage * 2.0;
                }
                else if (oneChar == '/')
                {
                    damage = damage / 2.0;
                }
            }

            return damage;
        }
    }
}