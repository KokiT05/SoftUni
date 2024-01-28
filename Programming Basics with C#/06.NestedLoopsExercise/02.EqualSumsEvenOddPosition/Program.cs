namespace _02.EqualSumsEvenOddPosition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            int unit = 0;
            int current = 0;

            int sumOddPosition = 0;
            int sumEvenPosition = 0;


            for (int i = firstNumber; i <= secondNumber; i++)
            {
                current = i;
                sumEvenPosition = 0;
                sumOddPosition = 0;
                for (int j = 6; j > 0; j--)
                {
                    unit = current % 10;

                    if (j % 2 == 0)
                    {
                        sumEvenPosition += unit;
                    }
                    else
                    {
                        sumOddPosition += unit;
                    }

                    current = current / 10;
                }

                if (sumOddPosition == sumEvenPosition)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}