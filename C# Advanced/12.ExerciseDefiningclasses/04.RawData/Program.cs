namespace _04.RawData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] information = Console.ReadLine().Split();
                string model = information[0];
                int engineSpeed = int.Parse(information[1]);
                int enginePower = int.Parse(information[2]);
                int cargoWeight = int.Parse(information[3]);
                string cargoType = information[4];

                Tire[] tires = new Tire[4];
                int count = 0;
                for (int j = 6; j <= 12; j = j = j + 2)
                {
                    double tirePressure = double.Parse(information[j - 1]);
                    int tireAge = int.Parse(information[j]);
                    Tire tire = new Tire(tireAge, tirePressure);
                    tires[count] = tire;
                    count++;
                }

                Engine engine = new Engine(enginePower, engineSpeed);
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string filter = Console.ReadLine().ToLower();

            List<Car> carsResult = cars;
            if (filter == "fragile")
            {
                carsResult = cars.Where(c => c.Cargo.Type == "fragile" &&
                                        c.Tires.Any(t => t.Pressure < 1.0))
                                .ToList();
            }
            else if (filter == "flamable")
            {
                carsResult = cars.Where(c => c.Cargo.Type == "flamable" &&
                                        c.Engine.Power > 250)
                                .ToList();
            }

            foreach (Car car in carsResult)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
