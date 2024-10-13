using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Library
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
            return new LibraryIterator<T>(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
