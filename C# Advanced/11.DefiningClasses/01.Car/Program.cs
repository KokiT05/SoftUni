namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] splitInput = input.Split(' ');

            List<Tire[]> tires = new List<Tire[]>();

            int indexOftire = 0;
            while (input != "No more tires")
            {
                splitInput = input.Split(' ');

                Tire[] tiresArray = new Tire[splitInput.Length / 2];
                for (int i = 0; i < splitInput.Length - 1; i = i + 2)
                {
                    int year = int.Parse(splitInput[i]);
                    double pressure = double.Parse(splitInput[i + 1]);

                    Tire tire = new Tire(year, pressure);
                    tiresArray[indexOftire] = tire;
                    indexOftire++;
                    if (indexOftire % 4 == 0)
                    {
                        indexOftire = 0;
                    }
                }

                tires.Add(tiresArray);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            
            List<Engine> engines = new List<Engine>();

            while (input != "Engines done")
            {
                splitInput = input.Split(' ');
                int horsePower = int.Parse(splitInput[0]);
                double cubicCapacity = double.Parse(splitInput[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            List<Car> cars = new List<Car>();

            while (input != "Show special")
            {
                splitInput = input.Split();
                string make = splitInput[0];
                string model = splitInput[1];
                int year = int.Parse(splitInput[2]);
                double fuelQuantity = double.Parse(splitInput[3]);
                double fuelConsumption = double.Parse(splitInput[4]);
                int engineIndex = int.Parse(splitInput[5]);
                int tiresIndex = int.Parse(splitInput[6]);

                Engine engine = engines[engineIndex];
                Tire[] tiresArray = tires[tiresIndex];
                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tiresArray);
                cars.Add(car);

                input = Console.ReadLine();
            }

            foreach (Car car in cars)
            {
                double tireSum = car.Tires.Sum(p => p.Pressure);
                int year = car.Year;
                int horsePower = car.Engine.HorsePower;

                bool isSpecial = year >= 2017 && horsePower >= 330 && (tireSum >= 9 && tireSum <= 10);
                if (isSpecial)
                {
                    double distance = 20;
                    car.Drive(distance);
                    Console.WriteLine(car.WhoAmI());
                }
            }
        }
    }
}
