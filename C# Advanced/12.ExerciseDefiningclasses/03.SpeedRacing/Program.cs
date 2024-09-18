namespace _03.SpeedRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            Car car = null;
            string[] information;

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                information = Console.ReadLine().Split();
                string model = information[0];
                double fuelAmount = double.Parse(information[1]);
                double fuelConsumptionForOneKm = double.Parse(information[2]);

                car = new Car(model, fuelAmount, fuelConsumptionForOneKm);

                if (!cars.ContainsKey(model))
                {
                    cars.Add(model, car);
                }
            }

            information = Console.ReadLine().Split();
            while (information[0] != "End")
            {
                string carModel = information[1];
                double amountKm = double.Parse(information[2]);

                if (cars.ContainsKey(carModel))
                {
                    cars[carModel].Drive(amountKm);
                }

                information = Console.ReadLine().Split();
            }

            foreach (Car carInformation in cars.Values)
            {
                Console.WriteLine(carInformation.CarInformation());
            }
        }
    }
}
