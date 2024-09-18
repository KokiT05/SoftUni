namespace DefiningClasses
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            // Task: 3
            //Family family = new Family();
            //Person person = new Person();

            //int n = int.Parse(Console.ReadLine());
            //for (int i = 0; i < n; i++)
            //{
            //    string[] inputData = Console.ReadLine().Split(' ');
            //    string name = inputData[0];
            //    int age = int.Parse(inputData[1]);

            //    person = new Person(name, age);
            //    family.AddMember(person);
            //}

            //person = family.GetOldestMember();
            //Console.WriteLine($"{person.Name} {person.Age}");

            //Task: 4
            Person person = new Person();
            List<Person> people = new List<Person>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] inputData = Console.ReadLine().Split(' ');
                string name = inputData[0];
                int age = int.Parse(inputData[1]);

                person = new Person(name, age);
                people.Add(person);
            }

            people = people.Where(p => p.Age > 30).OrderBy(p => p.Name).ToList();
            foreach (Person personInformation in people)
            {
                Console.WriteLine($"{personInformation.Name} - {personInformation.Age}");
            }
        }
        static List<Person> GetOldPeople(List<Person> people)
        {
            List<Person> peopleResult = new List<Person>();
            foreach (Person person in people)
            {
                if (person.Age > 30)
                {
                    peopleResult.Add(person);
                }
            }

            return peopleResult;
        }
    }
}
