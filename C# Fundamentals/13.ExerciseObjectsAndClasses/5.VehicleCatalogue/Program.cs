namespace _5.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Catalogue catalogue = new Catalogue();

            string command = Console.ReadLine();
            while (command.ToLower() != "end")
            {
                if (command != "Close the Catalogue")
                {
                    string[] dataInformation = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string typeOfVehicle = dataInformation[0];
                    string model = dataInformation[1];
                    string color = dataInformation[2];
                    double horsePower = double.Parse(dataInformation[3]);

                    if (typeOfVehicle.ToLower() == "car")
                    {
                        Car car = new Car(model, color, horsePower);
                        catalogue.Cars.Add(car);
                    }
                    else if (typeOfVehicle.ToLower() == "truck")
                    {
                        Truck truck = new Truck(model, color, horsePower);
                        catalogue.Trucks.Add(truck);
                    }
                }
                else
                {
                    int count = catalogue.Cars.Count;
                    double sumOfHorsePower = (catalogue.Cars.Sum(c => c.HorsePower) / count);
                    Console.WriteLine($"Cars have average horsepower of: {sumOfHorsePower:f2}");

                    count = catalogue.Trucks.Count;
                    sumOfHorsePower = (catalogue.Trucks.Sum(t => t.HorsePower) / count);
                    Console.WriteLine($"Trucks have average horsepower of: {sumOfHorsePower:f2}");
                }

                command = Console.ReadLine();
            }

            foreach (Car car in catalogue.Cars)
            {
                Console.WriteLine("Type: Car");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Color: {car.Color}");
                Console.WriteLine($"Horsepower: {car.HorsePower}");
            }

            foreach (Truck truck in catalogue.Trucks)
            {
                Console.WriteLine("Type: Truck");
                Console.WriteLine($"Model: {truck.Model}");
                Console.WriteLine($"Color: {truck.Color}");
                Console.WriteLine($"Horsepower: {truck.HorsePower}");
            }
        }
    }

    public class Catalogue
    {
        public Catalogue()
        {
            this.Trucks = new List<Truck>();
            this.Cars = new List<Car>();
        }

        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }

    public class Car
    {
        public Car(string model, string color, double horsePower)
        {
            this.Color = color;
            this.Model = model;
            this.HorsePower = horsePower;
        }

        public string Model { get; set; }

        public string Color { get; set; }

        public double HorsePower { get; set; }
    }

    public class Truck
    {
        public Truck(string model, string color, double horsePower)
        {
            this.Color = color;
            this.Model = model;
            this.HorsePower = horsePower;
        }

        public string Model { get; set; }

        public string Color { get; set; }

        public double HorsePower { get;}
    }
}