namespace _09.ExplicitInterfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] citizenInformation = input.Split();
                string name = citizenInformation[0];
                string country = citizenInformation[1];
                int age = int.Parse(citizenInformation[2]);

                Citizen citizen = new Citizen(name, age, country);
                IPerson person = citizen;
                Console.WriteLine(person.GetName());
                IResident resident = citizen;
                Console.WriteLine(resident.GetName());

                input = Console.ReadLine();
            }
        }
    }
}
