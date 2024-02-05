using System;

namespace _02.ExerciseBasicSyntaxConditionalStatements_Аnd_Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string personIs = string.Empty;
            int age = int.Parse(Console.ReadLine());

            if (age <= 2)
            {
                personIs = "baby";
            }
            else if (age >= 3 && age <= 13)
            {
                personIs = "child";
            }
            else if (age >= 14 && age <= 19)
            {
                personIs = "teenager";
            }
            else if (age >= 20 && age <= 65)
            {
                personIs = "adult";
            }
            else if (age >= 66)
            {
                personIs = "elder";
            }

            Console.WriteLine(personIs);
        }
    }
}
