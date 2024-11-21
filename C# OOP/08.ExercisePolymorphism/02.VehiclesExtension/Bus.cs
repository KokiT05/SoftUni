using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double PeopleFuelConsumption = 1.4;
        public Bus(double fuelQuantity, 
                    double fuelConsumptionInLitersPerKm, 
                    double tankCapacity) 
            : base(fuelQuantity, fuelConsumptionInLitersPerKm, tankCapacity)
        {
            base.FuelConsumptionInLitersPerKm += PeopleFuelConsumption;
        }
        public override string Driving(double distance)
        {
            return base.Driving(distance);
        }

        public string DrivingEmpty(double distance)
        {
            base.FuelConsumptionInLitersPerKm -= PeopleFuelConsumption;
            return base.Driving(distance);
        }
    }
}
