namespace _6.OrderByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            List<Person> personList = new List<Person>();
            while (command.ToLower() != "end")
            {
                string[] information = command
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                string name = information[0];
                string id = information[1];
                int age = int.Parse(information[2]);
                Person person = new Person(id, name, age);
                personList.Add(person);

                command = Console.ReadLine();
            }

            personList = personList.OrderBy(p => p.Age).ToList();

            foreach (Person person in personList)
            {
                Console.WriteLine($"{person.Name} with ID: {person.Id} is {person.Age} years old.");
            }

        }
    }

    public class Person
    {
        public Person(string id, string name, int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}