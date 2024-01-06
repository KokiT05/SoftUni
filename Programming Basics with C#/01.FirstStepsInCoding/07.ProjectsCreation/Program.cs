using System;

namespace _07.ProjectsCreation
{
    public class Program
    {
        static void Main(string[] args)
        {
            int necessaryTimeInHours = 3;

            string nameOfArchitect = Console.ReadLine();
            int numberOfProjects = int.Parse(Console.ReadLine());

            int totalNecessaryTime = necessaryTimeInHours * numberOfProjects;

            Console.WriteLine($"The architect {nameOfArchitect} will need " +
                $"{totalNecessaryTime} hours to complete {numberOfProjects} project/s.");
        }
    }
}
