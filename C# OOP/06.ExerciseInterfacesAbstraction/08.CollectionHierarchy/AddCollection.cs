using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CollectionHierarchy
{
    public class AddCollection<T> : IAddCollection<T>
    {
        private List<T> collection;

        public AddCollection()
        {
            this.collection = new List<T>();
        }
        public int Add(T item)
        {
            this.collection.Add(item);
            return this.collection.Count - 1;
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
