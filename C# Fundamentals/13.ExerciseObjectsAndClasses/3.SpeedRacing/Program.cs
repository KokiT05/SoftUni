namespace _3.SpeedRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] carInformation = Console.ReadLine()
                                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = carInformation[0];
                double fuelAmount = double.Parse(carInformation[1]);
                double fuelConsumptionForOneKm = double.Parse(carInformation[2]);
                double traveledKilometers = 0;
                Car car = new Car(model, fuelAmount, fuelConsumptionForOneKm, traveledKilometers);

                if (!cars.Select(c => c.Model).Contains(model))
                {
                    cars.Add(car);
                }
            }

            string command = Console.ReadLine();

            while (command.ToLower() != "end")
            {
                string[] commandArg = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = commandArg[0];
                string carModel = commandArg[1];
                double amountKm = double.Parse(commandArg[2]);

                if (action.ToLower() == "drive")
                {
                    foreach (Car car in cars)
                    {
                        if (car.Model == carModel)
                        {
                            car.Drive(amountKm);
                        }
                    }
                }


                command = Console.ReadLine();
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistance}");
            }
        }

        public class Car
        {
            public Car(string model, 
                        double fuelAmount, 
                        double fuelConsumptionPerKilometer, 
                        double travelKilometer)
            {
                this.Model = model;
                this.FuelAmount = fuelAmount;
                this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
                this.TraveledDistance = travelKilometer;
            }
            public string Model { get; set; }

            public double FuelAmount { get; set; }
            public double FuelConsumptionPerKilometer { get; set; }

            public double TraveledDistance { get; set; }

            public void Drive(double amountKilometers)
            {
                double result = FuelAmount - (FuelConsumptionPerKilometer * amountKilometers);
                if (result >= 0)
                {
                    FuelAmount = FuelAmount - (FuelConsumptionPerKilometer * amountKilometers);
                    TraveledDistance = TraveledDistance + amountKilometers;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }
        }
    }
}