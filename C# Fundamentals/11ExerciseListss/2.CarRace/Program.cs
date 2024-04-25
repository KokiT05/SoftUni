namespace _2.CarRace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console
                                    .ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList();

            double sumOfLeftRacer = 0;
            double sumOfRightRacer = 0;

            for (int i = 0; i < numbers.Count / 2; i++)
            {

                sumOfLeftRacer += numbers[i];
                sumOfRightRacer += numbers[numbers.Count - 1 - i];
                if (numbers[i] == 0)
                {
                    sumOfLeftRacer =Math.Round(sumOfLeftRacer * 0.8, 2);
                    sumOfRightRacer =Math.Round(sumOfRightRacer * 0.8, 2);
                }
            }

            string winner = sumOfLeftRacer < sumOfRightRacer ? "left" : "right";
            double winnerTime = sumOfLeftRacer < sumOfRightRacer ? sumOfLeftRacer : sumOfRightRacer;
            Console.WriteLine($"The winner is {winner} with total time: {winnerTime}");
        }
    }
}