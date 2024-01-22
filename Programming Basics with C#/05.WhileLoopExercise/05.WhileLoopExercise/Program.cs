using System;

namespace _01.OldBooks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countBook = 0;
            bool flag = false;

            string favoriteBook = Console.ReadLine();
            favoriteBook = favoriteBook.ToLower();

            string currentBook = Console.ReadLine();
            currentBook = currentBook.ToLower();

            while (currentBook != "no more books")
            {
                countBook++;

                if (currentBook == favoriteBook)
                {
                    flag = true;
                    break;
                }
                currentBook = Console.ReadLine();
            }

            if (flag)
            {
                Console.WriteLine($"You checked {countBook} books and found it");
            }
            else
            {
                Console.WriteLine("The book you search is not here! ");
                Console.WriteLine($"You checked {countBook} books. ");
            }
        }
    }
}
