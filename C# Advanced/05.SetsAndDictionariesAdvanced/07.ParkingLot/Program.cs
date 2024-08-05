namespace _07.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            HashSet<string> cars = new HashSet<string>();
            while (command != "END")
            {
                string[] commandArg = command.Split(", ");
                string direction = commandArg[0];
                string carNumber = commandArg[1];

                if (direction == "IN")
                {
                    cars.Add(carNumber);
                }
                else if (direction == "OUT")
                {
                    cars.Remove(carNumber);
                }

                command = Console.ReadLine();
            }

            if (cars.Count > 0)
            {
                foreach (string car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine($"Parking Lot is Empty");
            }
        }
    }
}
