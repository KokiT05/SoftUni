using System.Text;

namespace _5.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> catalogue = new List<Vehicle>();

            string command = Console.ReadLine();
            while (command.ToLower() != "end")
            {
                string[] cmdArg = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string type = cmdArg[0].ToLower();
                string model = cmdArg[1];
                string color = cmdArg[2].ToLower();
                int horsePower = int.Parse(cmdArg[3]);

                Vehicle currentVehicle = new Vehicle(type, model, color, horsePower);
                catalogue.Add(currentVehicle);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();
            while (command != "Close the Catalogue")
            {
                string model = command;
                bool isModelExist = catalogue.Select(x => x.Model).Contains(model);

                if (isModelExist)
                {
                    Vehicle currentVehicle = catalogue.First(v => v.Model == model);
                    Console.WriteLine(currentVehicle);
                }

                command = Console.ReadLine();
            }

            int countOfCars = 0;
            int coutOfTruck = 0;

            double sumOfCarsHorsePower = 0.0;
            double sumOfTruckHorsePower = 0.0;

            Vehicle vehicle = null;
            for (int i = 0; i < catalogue.Count; i++)
            {
                vehicle = catalogue[i];
                if (vehicle.Type.ToLower() == "car")
                {
                    countOfCars++;
                    sumOfCarsHorsePower += vehicle.HorsePower;
                }
                else if (vehicle.Type.ToLower() == "truck")
                {
                    coutOfTruck++;
                    sumOfTruckHorsePower += vehicle.HorsePower;
                }
            }

            if (countOfCars > 0)
            {
                sumOfCarsHorsePower = sumOfCarsHorsePower / countOfCars;
            }

            if (coutOfTruck > 0)
            {
                sumOfTruckHorsePower = sumOfTruckHorsePower / coutOfTruck;
            }

            Console.WriteLine($"Cars have average horsepower of: {sumOfCarsHorsePower:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {sumOfTruckHorsePower:f2}.");
        }

        public class Vehicle
        {
            public Vehicle(string type, string model, string color, int horsePower)
            {
                this.Type = type;
                this.Model = model;
                this.Color = color;
                this.HorsePower = horsePower;
            }

            public string Type { get; set; }

            public string Model { get; set; }

            public string Color { get; set; }

            public int HorsePower { get; set;}

            public override string ToString()
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine($"Type: {(Type == "car" ? "Car" : "Truck")}");
                stringBuilder.AppendLine($"Model: {Model}");
                stringBuilder.AppendLine($"Color: {Color}");
                stringBuilder.AppendLine($"Horsepower: {HorsePower}");

                return stringBuilder.ToString().TrimEnd();
            }
        }
    }
}