using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> list;
        private int index;
        private T item;

        public ListyIterator(IEnumerable<T> collection)
        {
            this.index = 0;
            this.list = new List<T>(collection);
        }

        public ListyIterator(params T[] collection)
        {
            this.index = 0;
            this.list = collection.ToList();
        }

        public bool Move()
        {
            //bool hasNext = this.HastNext();
            //if (hasNext)
            //{
            //    this.index++;
            //}

            //return hasNext;

            index++;
            if (index < list.Count)
            {
                return true;
            }

            return false;
        }

        public bool HasNext() // => this.index < this.list.Count - 1;
        {
            if (index == list.Count - 1)
            {
                return false;
            }

            return true;
        }

        public void Print()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            this.item = list[index];
            Console.WriteLine(this.item);
        }
    }
}
