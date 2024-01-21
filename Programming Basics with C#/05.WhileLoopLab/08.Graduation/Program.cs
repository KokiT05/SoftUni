using System;

namespace _08.Graduation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 1;
            double averageGrade = 0;
            double grade = 0;
            double allGrades = 0;
            int broke = 0;
            bool banished = false;

            string name = Console.ReadLine();

            while (count < 12)
            {
                grade = double.Parse(Console.ReadLine());

                if (grade < 4.00)
                {
                    broke++;
                    if (broke > 1)
                    {
                        banished = true;
                        count--;
                        break;
                    }
                }
                else
                {
                    allGrades += grade;
                }

                count++;
            }

            averageGrade = allGrades / count;
            Console.WriteLine(allGrades);
            Console.WriteLine(count);

            if (banished)
            {
                Console.WriteLine($"{name} has been excluded at {count} grade");
            }
            else
            {
                Console.WriteLine($"{name} graduated. Average grade: {averageGrade:f2}");
            }
        }
    }
}
