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

            //The code from lecture
            //string namePattern = @"[\W\d]";
            //string numberPattern = @"[\WA-Za-z]";


            string input = Console.ReadLine();
            while (input.ToLower() != "end of race")
            {
                //The code from lecture
                ///string name = Regex.Replace(input, namePattern, "");
                //string distance = Regex.Replace(input, numberPattern, "");
                // int sum = 0;

                //foreach (var/char digit in distance)
                //{
                    //int currentDigit = int.Parse(digit.ToString());
                    //sum += currentDigit;
                //}

                //if (participantsKm.ContainsKey(name))
                //{
                //    participantsKm[name] += sum;
                //}

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

            //The code from lecture
            //int count = 1;
            //foreach (var kvp in participantsKm.OrderByDescending(v => v.Value))
            //{
            //    string text = count == 1 ? "st" : count == 2 ? "nd" : "rd";
            //    Console.WriteLine($"{count++}{text} place: {kvp.Key}");

            //    if (count == 4)
            //    {
            //        break;
            //    }
            //}
            //
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