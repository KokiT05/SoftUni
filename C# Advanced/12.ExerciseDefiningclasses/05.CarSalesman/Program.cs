using System.Drawing;

namespace _05.CarSalesman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();
            Engine engine = new Engine("", 0);
            string[] splitInformation;

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                splitInformation = Console.ReadLine().Split(" ");
                string model = splitInformation[0];
                double power = double.Parse(splitInformation[1]);
                double displacement = 0;
                string efficiency = string.Empty;

                if (splitInformation.Length == 3)
                {
                    if (char.IsLetter(splitInformation[2][0]))
                    {
                        efficiency = splitInformation[2];
                    }
                    else
                    {
                        displacement = double.Parse(splitInformation[2]);
                    }
                }
                else if (splitInformation.Length == 4)
                {
                    displacement = double.Parse(splitInformation[2]);
                    efficiency = splitInformation[3];
                }

                engine = new Engine(model, power, displacement, efficiency);

                if (!engines.ContainsKey(model))
                {
                    engines.Add(model, engine);
                }
            }

            List<Car> cars = new List<Car>();

            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                splitInformation = Console.ReadLine().Split();
                string carModel = splitInformation[0];
                string engineModel = splitInformation[1];
                double weight = 0;
                string color = string.Empty;

                if (engines.ContainsKey(engineModel))
                {
                    engine = engines[engineModel];
                }

                if (splitInformation.Length == 3)
                {
                    if (char.IsLetter(splitInformation[2][0]))
                    {
                        color = splitInformation[2];
                    }
                    else
                    {
                        weight = double.Parse(splitInformation[2]);
                    }
                }
                else if (splitInformation.Length == 4)
                {
                    weight = double.Parse(splitInformation[2]);
                    color = splitInformation[3];
                }

                Car car = new Car(carModel, engine, weight, color);
                cars.Add(car);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car.Model);
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");

                if (car.Engine.Displacement == 0)
                {
                    Console.WriteLine($"    Displacement: n/a");
                }
                else
                {
                    Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                }

                if (car.Engine.Efficiency == "")
                {
                    Console.WriteLine($"    Efficiency: n/a");
                }
                else
                {
                    Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                }

                if (car.Weight == 0)
                {
                    Console.WriteLine($"  Weight: n/a");
                }
                else
                {
                    Console.WriteLine($"  Weight: {car.Weight}");
                }

                if (car.Color == "")
                {
                    Console.WriteLine($"  Color: n/a");
                }
                else
                {
                    Console.WriteLine($"  Color: {car.Color}");
                }
            }
        }
    }
}
