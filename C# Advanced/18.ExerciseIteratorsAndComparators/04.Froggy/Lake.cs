using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Froggy
{
    public class Lake<T> : IEnumerable<T>
    {
        private List<T> list;

        public Lake(params T[] collection)
        {
            this.list = new List<T>(collection);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i <= list.Count - 1; i = i + 2)
            {
                yield return list[i];
            }

            int startIndex = list.Count - 1;
            if (list.Count % 2 != 0)
            {
                startIndex--;
            }

            for (int i = startIndex; i >= 0 ; i = i - 2)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
