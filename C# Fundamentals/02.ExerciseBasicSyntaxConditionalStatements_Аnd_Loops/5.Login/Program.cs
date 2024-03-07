using System;
using System.Linq;
using System.Net.Sockets;
using System.Security;

namespace _5.Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = string.Empty;
            int count = 0;
            bool isBlock = false;

            string userName = Console.ReadLine();

            //first method
            for (int i = userName.Length - 1; i >= 0; i--)
            {
                password = password + $"{userName[i]}";
            }

            // second method
            //char[] charArray = userName.ToCharArray().Reverse().ToArray();
            //for (int i = 0; i < charArray.Length; i++)
            //{
            //    password += charArray[i];
            //}

            string currentPassword = Console.ReadLine();

            while (!currentPassword.Equals(password))
            {
                count++;
                if (count >= 4)
                {
                    isBlock = true;
                    break;
                }

                Console.WriteLine("Incorrect password. Try again.");

                currentPassword = Console.ReadLine();
            }

            if (!isBlock)
            {
                Console.WriteLine($"User {userName} logged in.");
            }
            else
            {
                Console.WriteLine($"User {userName} blocked!");
            }
        }
    }
}
