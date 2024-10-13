using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Library
{
    public class LibraryIterator<T> : IEnumerator<T>
    {
        private List<T> books;

        private int currentIndex = -1;
        public LibraryIterator(List<T> books)
        {
            this.books = books;
        }

        public T Current => books[currentIndex];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            currentIndex++;

            return currentIndex < books.Count;
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }
    }
}
