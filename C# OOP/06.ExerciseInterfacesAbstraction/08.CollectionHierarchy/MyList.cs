using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CollectionHierarchy
{
    public class MyList<T> : IAddRemoveCollection<T>
    {
        private Stack<T> collection;

        public MyList()
        {
            this.collection = new Stack<T>();
        }

        public int Used => this.collection.Count;
        public int Add(T item)
        {
            this.collection.Push(item);
            return 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (this.collection.Count > 0)
            {
                yield return this.collection.Pop();
            }
        }

        public T Remove()
        {
            if (this.collection.Count == 0)
            {
                return default(T);
            }

            T item = this.collection.Pop();
            return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
