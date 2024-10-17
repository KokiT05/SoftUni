using System;

namespace _05.ComparingObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] splitInput = input.Split(" ");
                string name = splitInput[0];
                int age = int.Parse(splitInput[1]);
                string town = splitInput[2];

                Person person = new Person(name, age, town);
                people.Add(person);

                input = Console.ReadLine();
            }

            int index = int.Parse(Console.ReadLine());

            Person currentPerson = people[index - 1];
            int countOfMathes = 0;
            int notEqual = 0;
            int totalNumberPeople = people.Count;

            foreach (Person person in people)
            {
                if (currentPerson.CompareTo(person) == 0)
                {
                    countOfMathes++;
                }
                else
                {
                    notEqual++;
                }
            }

            if (countOfMathes <= 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{countOfMathes} {notEqual} {totalNumberPeople}");
            }
        }
    }
}
