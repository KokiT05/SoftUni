using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.LibraryComparable
{
    public class LibraryIterator : IEnumerator<Book>
    {
        private List<Book> books;

        private int currentIndex = -1;
        public LibraryIterator(IEnumerable<Book> books)
        {
            this.books = new List<Book>(books);
        }

        public Book Current => books[currentIndex];

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
