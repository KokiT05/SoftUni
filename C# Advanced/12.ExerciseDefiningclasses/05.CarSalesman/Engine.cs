namespace _05.CarSalesman
{
    public class Engine
    {
        public Engine
            (string model, double power, double displacement = 0, string efficiency = "")
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public string Model { get; set; }
        public double Power { get; set; }
        public double Displacement { get; set; }
        public string Efficiency { get; set; }

    }
}
