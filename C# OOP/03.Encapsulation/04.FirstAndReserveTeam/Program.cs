namespace _04.FirstAndReserveTeam // PersonsInfo
{
    public class Program // StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            List<Person> persons = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();

                Person person = new Person
                (cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]));

                persons.Add(person);
            }

            Team team = new Team("SoftUni");
            foreach (Person currentPerson in persons)
            {
                team.AddPlayer(currentPerson);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players");
        }
    }
}
