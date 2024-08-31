namespace _05.FilterByAge
{
    public class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Person[] people = new Person[n];

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                string name = input[0];
                int age = int.Parse(input[1]);
                Person person = new Person(name, age);
                people[i] = person;
            }

            string filter = Console.ReadLine();
            int filterAge = int.Parse(Console.ReadLine());
            string formatter = Console.ReadLine();

            Func<Person, bool> condition = GetAgeCondition(filter, filterAge);
            Action<Person> formatterOutput = GetFormatter(formatter);
            PrintPeople(people, condition, formatterOutput);
        }

        static void PrintPeople(Person[] people, 
                                Func<Person, bool> condition,
                                Action<Person> formatter)
        {
            foreach (Person person in people)
            {
                if (condition(person))
                {
                    formatter(person);
                }
            }
        }

        static Func<Person, bool> GetAgeCondition(string filter, int filerAge)
        {
            switch (filter)
            {
                case "younger": return p => p.Age < filerAge;
                case "older": return p => p.Age >= filerAge;
                default:
                    return p => false;
            }
        }

        static Action<Person> GetFormatter(string formatter)
        {
            switch (formatter)
            {
                case "name": return p => { Console.WriteLine($"{p.Name}"); };
                case "age": return p => { Console.WriteLine($"{p.Age}"); };
                case "name age": return p => { Console.WriteLine($"{p.Name} - {p.Age}"); };
                default: return p => { Console.WriteLine(); };
            }
        }
    }
}
