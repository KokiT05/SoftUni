using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.GenericCountMethodStrings
{
    public class Box<T> where T : IComparable<T>
    {
        public Box(T value)
        {
            this.Value = value;
        }
        public T Value { get; set; }

        public int Comparer(List<Box<T>> list, T elemt)
        {
            int count = 0;

            for (int i = 0; i < list.Count; i++)
            {

                T secondElement = list[i].Value;
                int value = secondElement.CompareTo(elemt);

                if (value > 0)
                {
                    count++;
                }

            }

            return count;
        }

        public override string ToString()
        {
            return $"{Value.GetType().FullName}: {Value}";
        }
    }
}
