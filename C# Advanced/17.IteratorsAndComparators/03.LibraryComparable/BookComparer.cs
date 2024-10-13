using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.LibraryComparable
{
    public class BookComparer : IComparer<Book>
    {
        public int Compare(Book firstItem, Book secondItem)
        {
            return firstItem.CompareTo(secondItem);
        }
    }
}
