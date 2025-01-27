using _01.Singleton.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Singleton
{
    public class SingletonDataContainer : ISingletonContainer
    {
        private static SingletonDataContainer instance = new SingletonDataContainer();
        private Dictionary<string, int> capitals = new Dictionary<string, int>(); 

        private SingletonDataContainer()
        {
            Console.WriteLine("Initializing singleton object");

            string[] element = File.ReadAllLines("../../../capitals.txt");

            for(int i = 0; i < element.Length; i += 2)
            {
                capitals.Add(element[i], int.Parse(element[i + 1]));
            }

        }

        public static SingletonDataContainer Instance => instance;

        public int GetPopulation(string name)
        {
            return capitals[name];
        }

    }
}
