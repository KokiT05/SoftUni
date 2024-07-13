namespace _10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int durationOfGreenLight = int.Parse(Console.ReadLine());
            int durationOfFreeWindow = int.Parse(Console.ReadLine());

            Queue<char> carCharQueue = new Queue<char>();
            int countCarPass = 0;
            int timeToPass = durationOfGreenLight;

            string command = Console.ReadLine();
            while (command != "END")
            {
                if (command == "green")
                {
                    if (durationOfFreeWindow < carCharQueue.Count)
                    {
                        for (int i = 0; i < durationOfFreeWindow; i++)
                        {
                            carCharQueue.Dequeue();
                        }
                        Console.WriteLine($"{carCharQueue.Peek()} A crash happened!");
                        break;
                    }

                    if ()
                    {

                    }
                }
                else if (command != "green")
                {
                    carCharQueue = new Queue<char>(command.ToCharArray());
                }
            }
        }
    }
}
