namespace _04.TrainTheTrainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            double averageScoreofAllScore = 0;
            double sumOfAllScore = 0;
            double averageGrade = 0;
            double sumOfGrade = 0;

            double n = double.Parse(Console.ReadLine());

            string nameOgPresentation = Console.ReadLine();

            while (nameOgPresentation != "Finish") 
            {
                counter++;
                for (int i = 1; i <= n; i++)
                {
                    double grade = double.Parse((Console.ReadLine()));
                    sumOfGrade += grade;
                }

                averageGrade = sumOfGrade / n;
                sumOfAllScore += averageGrade;

                sumOfGrade = 0;

                Console.WriteLine($"{nameOgPresentation} - {averageGrade:f2}.");

                nameOgPresentation = Console.ReadLine();
            }
            averageScoreofAllScore = sumOfAllScore / counter;
            Console.WriteLine($"Student's final assessment is {averageScoreofAllScore:f2}.");
        }
    }
}