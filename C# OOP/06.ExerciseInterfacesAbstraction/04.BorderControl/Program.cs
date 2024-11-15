namespace _04.BorderControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> identifiables = new List<IIdentifiable>();
            IIdentifiable citizen;
            IIdentifiable robot;

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputType = input.Split();

                if (inputType.Length == 3)
                {
                    string name = inputType[0];
                    int age = int.Parse(inputType[1]);
                    string id = inputType[2];
                    citizen = new Citizen(name, age, id);
                    identifiables.Add(citizen);
                }
                else if (inputType.Length == 2)
                {
                    string model = inputType[0];
                    string id = inputType[1];
                    robot = new Robot(model, id);
                    identifiables.Add(robot);
                }

                input = Console.ReadLine();
            }

            string fakeId = Console.ReadLine();

            foreach (IIdentifiable identifiable in identifiables)
            {
                if (IsIdValid(identifiable.Id, fakeId))
                {
                    Console.WriteLine(identifiable.Id);
                }
            }

        }

        public static bool IsIdValid(string id, string fakeId)
        {
            string lastIdCode = id.Substring(id.Length - 3);
            if (lastIdCode.Equals(fakeId))
            {
                return true;
            }
            return false;
        }
    }
}
