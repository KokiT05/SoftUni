﻿using System;

namespace _09.PredicateParty_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(" ").ToList();

            List<string> guests = names;

            Func<List<string>, string, List<string>> func = (collection, conditional)
                =>
            {
                if (conditional == "")
                {

                }

                return collection;
            }; 

            string input = Console.ReadLine();
            string command = string.Empty;
            string conditional = string.Empty;
            string criteria = string.Empty;

            while (input != "Party!")
            {
                string[] splitInput = input.Split(" ");
                command = splitInput[0];
                conditional = splitInput[1];
                criteria = splitInput[2];

                func = GetFunc(guests, conditional, criteria);

                if (command.ToLower() == "remove")
                {
                    func(guests, conditional).ForEach(name => names.Remove(name));
                }
                else if (command.ToLower() == "double")
                {
                    guests.AddRange(func(guests, conditional));
                }

                input = Console.ReadLine();
            }

            if (guests.Count != 0)
            {

                Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        static Func<List<string>, string, List<string>> GetFunc
                            (List<string> guest, string conditional, string criteria)
        {
            if (conditional.ToLower() == "startswith")
            {
                return (guests, conditional) => guests.FindAll(name => name.StartsWith(criteria));
            }
            else if (conditional.ToLower() == "endswith")
            {
                return (guests, conditional) => guests.FindAll(name => name.EndsWith(criteria));
            }
            else if (conditional.ToLower() == "length")
            {
                int length = int.Parse(criteria);
                return (guests, conditional) => guests.FindAll(name => name.Length == length);
            }

            return (guest, conditional) => guest;
        }
    }
}
