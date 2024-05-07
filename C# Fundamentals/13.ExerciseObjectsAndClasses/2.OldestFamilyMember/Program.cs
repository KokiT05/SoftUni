namespace _2.OldestFamilyMember
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Family family = new Family();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] personInformation = Console.ReadLine()
                                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(personInformation[0], int.Parse(personInformation[1]));
                family.AddMember(person);
            }

            Person oldestPerson = family.GetOldestMember();
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }

        public class Family
        {
            public Family()
            {
                people = new List<Person>();
            }

            List<Person> people { get; set; }

            public void AddMember(Person person)
            {
                people.Add(person);
            }

            public Person GetOldestMember()
            {
                int age = 0;
                string name = string.Empty;
                foreach (Person person in people)
                {
                    if (person.Age > age)
                    {
                        age = person.Age;
                        name = person.Name;
                    }
                }

                Person oldestPerson = new Person(name, age);
                return oldestPerson;
            }
}

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
    }
}