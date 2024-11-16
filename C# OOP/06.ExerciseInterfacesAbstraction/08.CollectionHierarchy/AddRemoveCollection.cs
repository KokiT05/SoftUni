using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CollectionHierarchy
{
    public class AddRemoveCollection<T> : IAddRemoveCollection<T>
    {
        private List<T> collection;

        public AddRemoveCollection()
        {
            this.collection = new List<T>();
        }

        public int Add(T item)
        {
            this.collection.Insert(0, item);
            return 0;
        }
        public T Remove()
        {
            if (this.collection.Count == 0)
            {
                return default(T);
            }

            T item = this.collection[collection.Count - 1];
            this.collection.RemoveAt(collection.Count - 1);
            return item;
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in collection)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
