namespace _02.VehiclesExtension
{
    internal class Program // 
    {
        static void Main(string[] args)
        {
            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();
            Vehicle bus = CreateVehicle();

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
                else if (vehicleType == nameof(Bus))
                {
                    vehicle = bus;
                }

                try
                {
                    ProcessCommand(vehicle, command, parameter);
                }
                catch (Exception exception) 
                when (exception is InvalidOperationException || exception is ArgumentException)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
            //Vehicle vehicle = null;

            //string[] carInformation = Console.ReadLine().Split();
            //double carFuelQuantity = double.Parse(carInformation[1]);
            //double carLitersPerKm = double.Parse(carInformation[2]);
            //double carTankCapacity = double.Parse(carInformation[3]);
            //Vehicle car = new Car(carFuelQuantity, carLitersPerKm, carTankCapacity);

            //string[] truckInformation = Console.ReadLine().Split();
            //double truckFuelQuantity = double.Parse(truckInformation[1]);
            //double truckLitersPerKm = double.Parse(truckInformation[2]);
            //double truckTankCapacity = double.Parse(truckInformation[3]);
            //Vehicle truck = new Truck(truckFuelQuantity, truckLitersPerKm, truckTankCapacity);

            //string[] busInformation = Console.ReadLine().Split();
            //double busFuelQuantity = double.Parse(busInformation[1]);
            //double busLitersPerKm = double.Parse(busInformation[2]);
            //double busTankCapacity = double.Parse(busInformation[3]);
            //Vehicle bus = new Bus(busFuelQuantity, busLitersPerKm, busTankCapacity);

            //int n = int.Parse(Console.ReadLine());
            //for (int i = 0; i < n; i++)
            //{
            //    string[] inputCommand = Console.ReadLine().Split();
            //    string command = inputCommand[0];
            //    string vehicleType = inputCommand[1];
            //    //double vehicleParameter = double.Parse(inputCommand[2]);

            //    if (vehicleType == nameof(Car))
            //    {
            //        vehicle = car;
            //    }
            //    else if (vehicleType == nameof(Truck))
            //    {
            //        vehicle = truck;

            //    }
            //    else if (vehicleType == nameof(Bus))
            //    {
            //        vehicle = bus;
            //    }

            //    try
            //    {
            //        if (command == "Drive")
            //        {
            //            double distance = double.Parse(inputCommand[2]);
            //            Console.WriteLine(vehicle.Driving(distance));
            //            //Console.WriteLine(vehicle.Driving(vehicleParameter));
            //        }
            //        else if (command == "DriveEmpty")
            //        {
            //            Bus currentBus = (Bus)vehicle;
            //            double distance = double.Parse(inputCommand[2]);
            //            Console.WriteLine(currentBus.DrivingEmpty(distance));
            //        }
            //        else if (command == "Refuel")
            //        {
            //            double liters = double.Parse(inputCommand[2]);
            //            IsValidLiters(liters);
            //            vehicle.Refueling(liters);
            //            //vehicle.Refueling(vehicleParameter);
            //        }
            //    }
            //    catch (Exception exceptionMessage)
            //    {
            //        Console.WriteLine(exceptionMessage.Message);
            //    }
            //}

            //Console.WriteLine(car);
            //Console.WriteLine(truck);
            //Console.WriteLine(bus);
        }

        public static void IsValidLiters(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
        }

        public static void ProcessCommand(Vehicle vehicle, string command, double parameter)
        {
            if (command == "Drive")
            {
                Console.WriteLine(vehicle.Driving(parameter));
            }
            else if (command == "DriveEmpty")
            {
                Console.WriteLine(((Bus)vehicle).DrivingEmpty(parameter));
            }
            else if (command == "Refuel")
            {
                vehicle.Refueling(parameter);
            }
        }
        public static Vehicle CreateVehicle()
        {
            string[] parts = Console.ReadLine().Split();

            string type = parts[0];
            double fuelQuantity = double.Parse(parts[1]);
            double fuelConsumption = double.Parse(parts[2]);
            double tankCapacity = double.Parse(parts[3]);

            Vehicle vehicle = null;

            if (type == nameof(Car))
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == nameof(Truck))
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == nameof(Bus))
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }

            return vehicle;
        }
    }
}
