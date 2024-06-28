using System.Linq;
using System.Text;

namespace _04.PasswordReset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string newPassword = string.Empty;

            string inputData = Console.ReadLine();
            while (inputData != "Done")
            {
                string[] commandArg = inputData.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commandArg[0];

                if (command == "TakeOdd")
                {
                    newPassword = string.Empty;

                    // TODO: Make this with LINQ if is possible
                    for (int i = 1; i < password.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            newPassword += password[i];
                        }
                    }

                    password = newPassword;

                    Console.WriteLine(newPassword);
                }
                else if (command == "Cut")
                {
                    newPassword = string.Empty;
                    int startIndex = int.Parse(commandArg[1]);
                    int length = int.Parse(commandArg[2]);

                    string substring = password.Substring(startIndex, length);
                    List<string> passwordObject = password
                                    .Select(s => s.ToString())
                                    .ToList();
                    passwordObject.Remove(substring);

                    foreach (string item in passwordObject)
                    {
                        newPassword += item;
                    }

                    Console.WriteLine(newPassword);
                }
                else if (command == "Substitute")
                {
                    string subString = commandArg[1];
                    string substitute = commandArg[2];

                    if (newPassword.Contains(subString) == false)
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                    else
                    {
                        newPassword = newPassword.Replace(subString, substitute);
                        Console.WriteLine(newPassword);
                    }
                }

                inputData = Console.ReadLine();
            }

            Console.WriteLine($"Your password is: {newPassword}");
        }
    }
}