using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        public Parking(int capacity)
        {
            this.Cars = new Dictionary<string, Car>();
            this.Capacity = capacity;
        }

        public Dictionary<string, Car> Cars {  get; set; }

        public int Capacity { get; set; }

        public int Count { get => Cars.Count; }

        public string AddCar(Car car)
        {
            if (Cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
                //return;
            }

            if (Capacity <= Cars.Count)
            {
                return "Parking is full!";
                //return;
            }

            Cars.Add(car.RegistrationNumber, car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!Cars.ContainsKey(registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }

            Cars.Remove(registrationNumber);
            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            return Cars[registrationNumber];
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (string registrationNumber in registrationNumbers)
            {
                if (Cars.ContainsKey(registrationNumber))
                {
                    Cars.Remove(registrationNumber);
                }
            }
        }
    }
}
