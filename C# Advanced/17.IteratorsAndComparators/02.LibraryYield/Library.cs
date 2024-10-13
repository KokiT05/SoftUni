using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.LibraryYield
{
    public class Library<T> : IEnumerable<T>
    {
        private readonly List<T> books;

        public Library(params T[] books)
        {
            this.books = new List<T>(books);
        }

        public Library()
        {
            this.books = new List<T>();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T book in books)
            {
                yield return book;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
