using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Facade
{
    public class CarInfoBuilder : CarBuilderFacade
    {
        public CarInfoBuilder(Car car)
        {
            base.Car = car;
        }

        public CarInfoBuilder WithType(string type)
        {
            base.Car.Type = type;
            return this;
        }

        public CarInfoBuilder WithColor(string color)
        {
            base.Car.Color = color;
            return this;
        }

        public CarInfoBuilder WithNumberOfDoors(int number)
        {
            base.Car.NumberOfDoors = number;
            return this;
        }
    }
}
