namespace _05.CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine, double weight = 0, string color = "")
        {
            this.Model = model; 
            this.Engine = engine;
            this.Weight = weight; 
            this.Color = color;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public double Weight { get; set; }

        public string Color { get; set; }
    }
}
