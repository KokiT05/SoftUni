﻿namespace _02.Facade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new CarBuilderFacade()
                .Info
                    .WithType("BMW")
                    .WithColor("Black")
                    .WithNumberOfDoors(5)
                .Built
                    .InCity("Leipzing")
                    .AtAddress("Some address 254")
                .Build();

            Console.WriteLine(car);
        }
    }
}
