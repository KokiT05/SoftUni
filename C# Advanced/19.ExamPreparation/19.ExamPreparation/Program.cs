namespace _19.ExamPreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(LiliesRead());
            Queue<int> roses = new Queue<int>(RosesInput());

            int storedFlowers = 0;
            int countOfWreaths = 0;
            while (roses.Count > 0 && lilies.Count > 0)
            {
                int lili = lilies.Pop();
                int rose = roses.Dequeue();
                int wreath = lili + rose;

                if (wreath < 15)
                {
                    storedFlowers += wreath;
                    continue;
                }

                while (wreath > 15)
                {
                    wreath -= 2;
                }

                if (wreath == 15)
                {
                    countOfWreaths++;
                }
                else
                {
                    storedFlowers += wreath;
                }
            }

            int needWreath = 5;
            int leftWreath = storedFlowers / 15;
            countOfWreaths += leftWreath;
            PrintWreathMessage(countOfWreaths, needWreath);
        }

        static void PrintWreathMessage(int countOfWreaths, int needWreath)
        {
            if (countOfWreaths >= needWreath)
            {
                Console
                .WriteLine($"You made it, you are going to the competition with {countOfWreaths} wreaths!");
            }
            else
            {
                Console
                .WriteLine($"You didn't make it, you need {needWreath - countOfWreaths} wreaths more!");
            }
        }

        static int[] LiliesRead()
        {
             int[] liliesInput = Console.ReadLine()
                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

            return liliesInput;
        }

        static int[] RosesInput()
        {
            int[] rosesInput = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            return rosesInput;
        }
    }
}
