namespace _02.VehiclesExtension
{
    internal class Program // 
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = null;

            string[] carInformation = Console.ReadLine().Split();
            double carFuelQuantity = double.Parse(carInformation[1]);
            double carLitersPerKm = double.Parse(carInformation[2]);
            double carTankCapacity = double.Parse(carInformation[3]);
            Vehicle car = new Car(carFuelQuantity, carLitersPerKm, carTankCapacity);

            string[] truckInformation = Console.ReadLine().Split();
            double truckFuelQuantity = double.Parse(truckInformation[1]);
            double truckLitersPerKm = double.Parse(truckInformation[2]);
            double truckTankCapacity = double.Parse(truckInformation[3]);
            Vehicle truck = new Truck(truckFuelQuantity, truckLitersPerKm, truckTankCapacity);

            string[] busInformation = Console.ReadLine().Split();
            double busFuelQuantity = double.Parse(busInformation[1]);
            double busLitersPerKm = double.Parse(busInformation[2]);
            double busTankCapacity = Double.Parse(busInformation[3]);
            Vehicle bus = new Bus(busFuelQuantity, busLitersPerKm, busTankCapacity);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] inputCommand = Console.ReadLine().Split();
                string command = inputCommand[0];
                string vehicleType = inputCommand[1];
                //double vehicleParameter = double.Parse(inputCommand[2]);

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
                    //Console.WriteLine(vehicle.Driving(vehicleParameter));
                }
                else if (command == "DriveEmpty")
                {
                    double distance = Double.Parse(inputCommand[3]);
                    Console.WriteLine(vehicle.Driving());
                }
                else if (command == "Refuel")
                {
                    double liters = double.Parse(inputCommand[2]);
                    vehicle.Refueling(liters);
                    //vehicle.Refueling(vehicleParameter);
                }
            }

        }
    }
}
