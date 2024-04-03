namespace _04.PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool firstConditional = PasswordLength(password);
            bool secondConditional = PasswordStruct(password);
            bool thirdConditional = PasswordLastSymbols(password);

            if (firstConditional && secondConditional && thirdConditional)
            {
                Console.WriteLine($"Password is valid");
            }
        }

        static bool PasswordLength(string password) 
        {
            if (password.Length < 6 || password.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                return false;
            }

            return true;
        }


        static bool PasswordStruct(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                if (!char.IsLetter(password[i]) && !char.IsDigit(password[i]))
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                    return false;
                }
            }

            return true;
        }


        static bool PasswordLastSymbols(string password)
        {
            string lastTWoSymbols = password[password.Length - 1].ToString()
                                    + password[password.Length - 2].ToString();

            if (!char.IsDigit(lastTWoSymbols[0]) && !char.IsDigit(lastTWoSymbols[1]))
            {
                Console.WriteLine("Password must have at least 2 digits");
                return false;
            }

            return true;
        }
    }
}