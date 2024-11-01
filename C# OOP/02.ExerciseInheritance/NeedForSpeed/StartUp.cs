using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            FamilyCar familyCar = new FamilyCar(120, 50);
            familyCar.Drive(31);
            Console.WriteLine(familyCar.Fuel);
        }
    }
}
