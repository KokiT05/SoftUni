using System.Formats.Asn1;

namespace _03.MovingTarget
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToList();


            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] commandArg = command.Split(' ');
                string operation = commandArg[0];
                int index = int.Parse(commandArg[1]);
                int number = int.Parse(commandArg[2]);

                if (operation == "Shoot" && isCorrectIndex(index, targets))
                {
                    targets[index] -= number;
                    if (targets[index] <= 0)
                    {
                        targets.RemoveAt(index);
                    }
                }
                else if (operation == "Add")
                {
                    if (isCorrectIndex(index, targets))
                    {
                        targets.Insert(index, number);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                }
                else if (operation == "Strike")
                {
                    if (index + number >= targets.Count || index - number < 0)
                    {
                        Console.WriteLine("Strike missed!");

                    }
                    else
                    {
                        int currentIndex = index - number;
                        for (int i = index - number; i < index; i++)
                        {
                            targets.RemoveAt(currentIndex);
                            index--;
                        }

                        for (int i = 0; i <= number; i++)
                        {
                            targets.RemoveAt(index);
                        }
                    }
                }
                
                command = Console.ReadLine();
            }

            Console.WriteLine($"{string.Join('|', targets)}");
        }

        static bool isCorrectIndex(int index, ICollection<int> collection)
        {
            if (index >= 0 && index < collection.Count)
            {
                return true;
            }

            return false;
        }
    }
}