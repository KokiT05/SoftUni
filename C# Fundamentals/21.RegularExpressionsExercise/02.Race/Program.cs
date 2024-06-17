using System.Text.RegularExpressions;

namespace _02.Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] participants = Console.ReadLine().Split(", ");

            Dictionary<string, double> participantsKm = new Dictionary<string, double>();
            foreach (string participant in participants) 
            {
                if (participantsKm.ContainsKey(participant) == false)
                {
                    participantsKm.Add(participant, 0);
                }
            }

            string patternName = @"([A-Za-z]+)";
            string patternKm = @"(\d)";
            MatchCollection matches;


            string input = Console.ReadLine();
            while (input.ToLower() != "end of race")
            {
                string name = string.Empty;
                double km = 0;
                matches = Regex.Matches(input, patternName);
                for (int i = 0; i < matches.Count; i++)
                {
                    name += matches[i];
                }

                matches = Regex.Matches(input, patternKm);
                for (int i = 0; i < matches.Count; i++)
                {
                    km += double.Parse(matches[i].ToString());
                }

                if (participantsKm.ContainsKey(name))
                {
                    participantsKm[name] += km;
                }

                input = Console.ReadLine();
            }

            participantsKm = 
            participantsKm.OrderByDescending(v => v.Value).ToDictionary(k => k.Key, v => v.Value);

            int count = 1;
            foreach (string name in participantsKm.Keys)
            {
                if (count == 1)
                {
                    Console.WriteLine($"{count}st place: {name}");
                }
                else if (count == 2)
                {
                    Console.WriteLine($"{count}nd place: {name}");
                }
                else if (count == 3)
                {
                    Console.WriteLine($"{count}rd place: {name}");
                }
                count++;
            }

        }
    }
}