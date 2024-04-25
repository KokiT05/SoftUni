namespace _5.DrumSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            int[] drumSet = Console.ReadLine()
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();

            List<int> copyDrumSet = new List<int>(drumSet.Length);
            for (int i = 0; i < drumSet.Length; i++)
            {
                copyDrumSet.Add(drumSet[i]);
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "stop")
            {
                for (int i = 0; i < drumSet.Length; i++)
                {
                    drumSet[i] = drumSet[i] - 3;
                }
            }

            Console.WriteLine(string.Join(' ', copyDrumSet));
            Console.WriteLine(string.Join(' ', drumSet));
            //int[] copyDrumSet = new int[drumSet.Length];
            //drumSet.CopyTo(copyDrumSet, 0);

            //string command = Console.ReadLine();
            //while (command != "Hit it again, Gabsy!")
            //{
            //    int hitPower = int.Parse(command);
            //    double drumPrice = 0;
            //    for (int i = 0; i < drumSet.Length; i++)
            //    {
            //        drumPrice = copyDrumSet[i] * 3;
            //        if (drumSet[i] - hitPower <= 0 && savings - drumPrice >= 0)
            //        {
            //            savings -= drumPrice;
            //            drumSet[i] = copyDrumSet[i];
            //        }
            //        else if (drumSet[i] - hitPower <= 0 && savings - drumPrice < 0)
            //        {
            //            drumSet[i] = 0;
            //        }
            //        else
            //        {
            //            drumSet[i] -= hitPower;
            //        }
            //    }

            //    command = Console.ReadLine();
            //}

            //Console.WriteLine(string.Join(' ', drumSet.Where(ds => ds > 0)));
            //Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}