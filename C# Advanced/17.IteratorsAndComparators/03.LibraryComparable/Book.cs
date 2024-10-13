using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.LibraryComparable
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = new List<string>(authors);
        }

        public string Title { get; set; }

        public int Year { get; set; }

        public List<string> Authors { get; set; }

        public int CompareTo(Book book)
        {
            if (this.Year != book.Year)
            {
                return this.Year - book.Year;
            }

            return this.Title.CompareTo(book.Title);
        }

        public override string ToString()
        {
            return $"{this.Title} -> {this.Year}";
        }
    }
}
