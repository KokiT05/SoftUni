using System;
using System.Security.Cryptography;

namespace _10.LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfFiled = int.Parse(Console.ReadLine());
            string[] filed = new string[sizeOfFiled];
            for (int i = 0; i < sizeOfFiled; i++)
            {
                filed[i] = "0";
            }

            string indexes = Console.ReadLine();
            indexes = indexes.Replace(" ", "");
            for (int i = 0; i < indexes.Length; i++)
            {
                int currentIndex = int.Parse(indexes[i].ToString());

                if (currentIndex >= 0 && currentIndex < filed.Length)
                {
                    filed[currentIndex] = "1";
                }
            }

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] parstOfCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int ladybugIndex = int.Parse(parstOfCommand[0]);
                string diretion = parstOfCommand[1];
                int flyLength = int.Parse(parstOfCommand[2]);

                bool action = false;

                if ((ladybugIndex >= 0 && ladybugIndex < filed.Length) &&
                    (filed[ladybugIndex] == "1"))
                {
                    action = true;
                }

                if (action && diretion == "right")
                {

                }
                else if (action && diretion == "left")
                {

                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", filed));
        }
    }
}
