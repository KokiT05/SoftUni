﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;

        public Clinic(int capacity)
        {
            this.data = new List<Pet>();
            this.Capacity = capacity;
        }

        public int Capacity { get; set; }

        public int Count { get { return data.Count; } }

        public void Add(Pet pet)
        {
            if (data.Count < Capacity)
            {
                data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet pet = data.FirstOrDefault(p => p.Name == name);

            if (pet == null)
            {
                return false;
            }

            data.Remove(pet);
            return true;
        }

        public Pet GetPet(string name, string owner)
        {
            Pet pet = data.FirstOrDefault(p => p.Name == name && p.Owner == owner);
            return pet;
        }

        public Pet GetOldestPet()
        {
            Pet pet = data.OrderByDescending(p => p.Age).FirstOrDefault();
            return pet;
        
        }
        public string GetStatistics()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("The clinic has the following patients:");
            foreach (Pet pet in data)
            {
                output.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return output.ToString();
        }
    }
}
