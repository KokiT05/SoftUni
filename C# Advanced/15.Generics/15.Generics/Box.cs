using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Generics
{
    internal class Box<T>
    {
        private List<T> list;

        public Box()
        {
            this.list = new List<T>();
        }

        public int Count { get { return list.Count; } }

        public void Add(T item)
        {
            list.Insert(0, item);
        }

        public T Remove()
        {
            T value = list[0];
            list.RemoveAt(0);

            return value;
        }
    }
}
