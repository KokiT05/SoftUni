namespace _06.EqualityLogic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<Person> hashSetPeople = new HashSet<Person>();
            SortedSet<Person> sortedSetPeople = new SortedSet<Person>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                string[] inputData = Console.ReadLine().Split(" ");
                string name = inputData[0];
                int age = int.Parse(inputData[1]);

                Person person = new Person(name, age);
                hashSetPeople.Add(person);
                sortedSetPeople.Add(person);
                Console.WriteLine(person.GetHashCode());
            }

            Console.WriteLine(hashSetPeople.Count);
            Console.WriteLine(sortedSetPeople.Count);
        }
    }
}
