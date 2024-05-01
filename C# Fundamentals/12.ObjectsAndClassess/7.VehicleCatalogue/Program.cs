namespace _7.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();

            string command = Console.ReadLine();
            while (command.ToLower() != "end")
            {
                string[] dataInformation = command.Split('/', StringSplitOptions.RemoveEmptyEntries);
                CreateObject(dataInformation, catalog);
                command = Console.ReadLine();
            }

            catalog.Trucks = catalog.Trucks.OrderBy(t => t.Brand).ToList();
            catalog.Cars = catalog.Cars.OrderBy(c => c.Brand).ToList();

            if (catalog.Cars.Count != 0)
            {
                PrintCar(catalog);
            }

            if (catalog.Trucks.Count != 0)
            {
                PrintTruck(catalog);
            }
        }

        public static void CreateObject(string[] information, Catalog catalog)
        {
            string type = information[0];
            string brand = information[1];
            string model = information[2];
            double horsePowerOrWeight = double.Parse(information[3]);

            if (type.ToLower() == "car")
            {
                Car car = new Car(brand, model, horsePowerOrWeight);
                catalog.Cars.Add(car);
            }
            else if (type.ToLower() == "truck")
            {
                Truck truck = new Truck(brand, model, horsePowerOrWeight);
                catalog.Trucks.Add(truck);
            }
        }

        public static void PrintTruck(Catalog catalog)
        {
            Console.WriteLine("Trucks:");
            foreach (Truck truck in catalog.Trucks)
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }
        }

        public static void PrintCar(Catalog catalog)
        {
            Console.WriteLine("Cars:");
            foreach (Car car in catalog.Cars)
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            }
        }
    }

    public class Truck
    {
        public Truck(string brand, string model, double weight)
        {
            this.Brand = brand;
            this.Model = model;
            this.Weight = weight;
        }

        public string Brand { get; set; }

        public string Model { get; set; }

        public double Weight { get; set; }
    }

    public class Car
    {
        public Car(string brand, string model, double horsePower)
        {
            this.Brand = brand;
            this.Model = model;
            this.HorsePower = horsePower;
        }

        public string Brand { get; set; }

        public string Model { get; set; }

        public double HorsePower { get; set; }
    }

    public class Catalog
    {
        public Catalog()
        {
            this.Cars = new List<Car>();
            this.Trucks = new List<Truck>();
        }

        public List<Car> Cars { get; set;}

        public List<Truck> Trucks { get; set;}
    }
}