﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.LibraryYield
{
    public class Book
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

        public override string ToString()
        {
            return $"{this.Title} -> {this.Year}";
        }
    }
}
