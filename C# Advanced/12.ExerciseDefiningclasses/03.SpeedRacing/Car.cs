using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionKilometer;
        private double travelledDistance;

        public Car(string model, double fuelAmount, double fuelConsumptionKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionKilometer = fuelConsumptionKilometer;
            this.TravelledDistance = 0;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void Drive(double distance)
        {
            bool canDrive = this.FuelAmount - (distance * this.FuelConsumptionKilometer) >= 0;
            if (canDrive)
            {
                this.TravelledDistance += distance;
                this.FuelAmount -= (distance * this.FuelConsumptionKilometer);
            }
            else
            {
                Console.WriteLine($"Insufficient fuel for the drive");
            }
        }

        public string CarInformation()
        {
            return $"{this.Model} {this.FuelAmount:f2} {this.TravelledDistance}";
        }
    }
}
