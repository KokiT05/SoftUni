namespace _4.RawData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] carInformatin = Console.ReadLine()
                                                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = carInformatin[0];
                int engineSpeed = int.Parse(carInformatin[1]);
                int enginePower = int.Parse(carInformatin[2]);
                int cargoWeight = int.Parse(carInformatin[3]);
                string cargoType = carInformatin[4];
                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Car car = new Car(model, engine, cargo);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command.ToLower() == "fragile")
            {
                foreach (Car car in cars)
                {
                    if (car.Cargo.CargoType == "fragile" && car.Cargo.CargWeight < 1000)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
            else if(command.ToLower() == "flamable")
            {
                foreach (Car car in cars)
                {
                    if (car.Cargo.CargoType == "flamable" && car.Engine.EnginePower > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }
    }

    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
        }
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }
    }

    public class Engine
    {
        public Engine(int engineSpeed, int enginePower)
        {
            this.EngineSpeed = engineSpeed;
            this.EnginePower = enginePower;
        }

        public int EngineSpeed { get; set; }

        public int EnginePower { get; set; }


    }

    public class Cargo
    {
        public Cargo(int cargWeight, string cargoType)
        {
            CargWeight = cargWeight;

            CargoType = cargoType;

        }

        public int CargWeight { get; set; }

        public string CargoType { get; set; }
    }
}