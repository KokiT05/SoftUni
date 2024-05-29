namespace _04.SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbersOfLines = int.Parse(Console.ReadLine());

            Dictionary<string, string> userNameLicensePlate = new Dictionary<string, string>(numbersOfLines);
            for (int i = 0; i < numbersOfLines; i++)
            {
                string[] inputData = Console.ReadLine().Split(' ');
                string command = inputData[0];
                string userName = inputData[1];

                if (command == "register")
                {
                    string licensePlateNumber = inputData[2];
                    RegisterUserSuccessfully(userName, licensePlateNumber, userNameLicensePlate);
                }
                else if (command == "unregister") 
                {
                    UnregisterUserSuccessfully(userName, userNameLicensePlate);
                }

            }

            foreach (KeyValuePair<string, string> user in userNameLicensePlate)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }

        static void RegisterUserSuccessfully(string userName,string licensePlate ,Dictionary<string, string> userAndLicenses)
        {
            if (userAndLicenses.ContainsKey(userName) == false)
            {
                userAndLicenses.Add(userName, licensePlate);
                Console.WriteLine($"{userName} registered {licensePlate} successfully");
            }
            else
            {
                Console.WriteLine($"ERROR: already registered with plate number {licensePlate}");
            }
        }

        static void UnregisterUserSuccessfully(string userNeme
                                            , Dictionary<string, string> userLicesePlate)
        {
            if (userLicesePlate.ContainsKey(userNeme))
            {
                userLicesePlate.Remove(userNeme);
                Console.WriteLine($"{userNeme} unregistered successfully");
            }
            else
            {
                Console.WriteLine($"");
                Console.WriteLine($"ERROR: user {userNeme} not found");
            }
        }


    }
}