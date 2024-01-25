using System;

namespace _01.OldBooks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            bool isBookFound = false;

            string favoriteBook = Console.ReadLine();
            favoriteBook = favoriteBook.ToLower();

            string currentBook = Console.ReadLine();
            currentBook = currentBook.ToLower();

            while (currentBook != "no more books")
            {

                if (currentBook == favoriteBook)
                {
                    isBookFound = true;
                    break;
                }
                else
                {
                    counter++;
                }

                currentBook = Console.ReadLine();
                currentBook = currentBook.ToLower();
            }

            if (isBookFound)
            {
                Console.WriteLine($"You checked {counter} books and found it.");
            }
            else
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {counter} books.");
            }
        }
    }
}
