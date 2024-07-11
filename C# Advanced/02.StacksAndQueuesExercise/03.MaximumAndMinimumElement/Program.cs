namespace _03.MaximumAndMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbersStack = new Stack<int>();

            int Nlines = int.Parse(Console.ReadLine());
            for (int i = 1; i <= Nlines; i++)
            {
                int[] inputData = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int command = inputData[0];

                switch (command)
                {
                    case 1:
                        numbersStack.Push(inputData[1]);
                        break;
                    case 2:
                        numbersStack.Pop();
                        break;
                    case 3:
                        if (numbersStack.Count > 0)
                        {
                            //Console.WriteLine(numbersStack.Max());
                            int maxNumber = numbersStack.Peek();
                            foreach (int number in numbersStack)
                            {
                                if (number > maxNumber)
                                {
                                    maxNumber = number;
                                }
                            }
                            Console.WriteLine(maxNumber);
                        }
                        break;
                    case 4:
                        if (numbersStack.Count > 0)
                        {
                            Console.WriteLine(numbersStack.Min());
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", numbersStack));
        }
    }
}
