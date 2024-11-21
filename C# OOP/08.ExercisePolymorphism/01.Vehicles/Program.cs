namespace _01.Vehicles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = null;

            string[] carInformation = Console.ReadLine().Split();
            double carFuelQuantity = double.Parse(carInformation[1]);
            double carLitersPerKm = double.Parse(carInformation[2]);
            Vehicle car = new Car(carFuelQuantity, carLitersPerKm);

            string[] truckInformation = Console.ReadLine().Split();
            double truckFuelQuantity = double.Parse(truckInformation[1]);
            double truckLitersPerKm = double.Parse(truckInformation[2]);
            Vehicle truck = new Truck(truckFuelQuantity, truckLitersPerKm);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] inputCommand = Console.ReadLine().Split();
                string command = inputCommand[0];
                string vehicleType = inputCommand[1];

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
                    double distance = double.Parse(inputCommand[2]);
                    Console.WriteLine(vehicle.Driving(distance));
                }
                else if (command == "Refuel")
                {
                    double liters = double.Parse(inputCommand[2]);
                    vehicle.Refueling(liters);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
