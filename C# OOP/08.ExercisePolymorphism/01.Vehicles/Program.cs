namespace _01.Vehicles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();

            Vehicle vehicle = null;

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] inputCommand = Console.ReadLine().Split();
                string command = inputCommand[0];
                string vehicleType = inputCommand[1];
                double parameter = double.Parse(inputCommand[2]);

                if (vehicleType == nameof(Car))
                {
                    vehicle = car;
                }
                else if (vehicleType == nameof(Truck))
                {
                    vehicle = truck;

                }
                    
                if (command == "Drive")
                {
                    try
                    {
                        Console.WriteLine(vehicle.Driving(parameter));
                    }
                    catch (InvalidOperationException message)
                    {
                        Console.WriteLine(message.Message);
                    }
                }
                else if (command == "Refuel")
                {
                    vehicle.Refueling(parameter);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        public static Vehicle CreateVehicle()
        {
            string[] parts = Console.ReadLine().Split();

            string type = parts[0];
            double fuelQuantity = double.Parse(parts[1]);
            double fuelConsumption = double.Parse(parts[2]);

            Vehicle vehicle = null;

            if (type == nameof(Car))
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if (type == nameof(Truck))
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }

            return vehicle;
        }
    }
}
