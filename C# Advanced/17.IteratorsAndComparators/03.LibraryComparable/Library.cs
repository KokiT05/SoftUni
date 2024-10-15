using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.LibraryComparable
{
    public class Library : IEnumerable<Book>
    {
        private readonly SortedSet<Book> books;

        public Library(IEnumerable<Book> books)
        {
            IComparer<Book> comparer = new BookComparer();
            this.books = new SortedSet<Book>(books, comparer);
        }

        public Library()
        {
            IComparer<Book> comparer = new BookComparer();
            this.books = new SortedSet<Book>(comparer);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
