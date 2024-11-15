namespace _05.BirthdayCelebrations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IBirthable> birthdays = new List<IBirthable>();
            IBirthable citizen;
            IBirthable pet;
            IRobot robot;

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputType = input.Split();
                string type = inputType[0];

                if (type.Equals("Pet"))
                {
                    string name = inputType[1];
                    string birthday = inputType[2];
                    pet = new Pet(name, birthday);
                    birthdays.Add(pet);
                }
                else if (type.Equals("Citizen"))
                {
                    string name = inputType[1];
                    int age = int.Parse(inputType[2]);
                    string id = inputType[3];
                    string birthday = inputType[4];
                    citizen = new Citizen(name, age, id, birthday);
                    birthdays.Add(citizen);
                }
                else if (type.Equals("Robot"))
                {
                    string model = inputType[1];
                    string id = inputType[2];
                    robot = new Robot(model, id);
                }

                input = Console.ReadLine();
            }

            string specificYear = Console.ReadLine();

            foreach (IBirthable birthday in birthdays)
            {
                if (birthday.Birthday.Contains(specificYear))
                {
                    Console.WriteLine(birthday.Birthday);
                }
            }
        }
    }
}
