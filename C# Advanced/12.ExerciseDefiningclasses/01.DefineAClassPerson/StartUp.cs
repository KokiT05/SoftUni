namespace DefiningClasses
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Family family = new Family();
            Person person = new Person();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] inputData = Console.ReadLine().Split(' ');
                string name = inputData[0];
                int age = int.Parse(inputData[1]);

                person = new Person(name, age);
                family.AddMember(person);
            }

            person = family.GetOldestMember();
            Console.WriteLine($"{person.Name} {person.Age}");
        }
    }
}
