using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double BusAirConditionModifier = 1.4;
        public Bus(double fuelQuantity, 
                    double fuelConsumptionInLitersPerKm, 
                    double tankCapacity) 
            : base(fuelQuantity, fuelConsumptionInLitersPerKm, tankCapacity, BusAirConditionModifier)
        {
        }

        public string DrivingEmpty(double distance)
        {
            double requiredFuel = this.FuelConsumption * distance;

            if (requiredFuel > this.FuelQuantity)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= requiredFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }
        //public override string Driving(double distance)
        //{
        //    return base.Driving(distance);
        //}

        //public string DrivingEmpty(double distance)
        //{
        //    base.FuelConsumptionInLitersPerKm -= PeopleFuelConsumption;
        //    return base.Driving(distance);
        //}
    }
}
