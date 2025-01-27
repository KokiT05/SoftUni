using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Facade
{
    public class CarAddressBuilder : CarBuilderFacade
    {
        public CarAddressBuilder(Car car)
        {
            base.Car = car;
        }

        public CarAddressBuilder InCity(string city)
        {
            base.Car.City = city;
            return this;
        }

        public CarAddressBuilder AtAddress(string address)
        {
            base.Car.Address = address;
            return this;
        }


    }
}
