namespace _03.LibraryComparable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book[] books = new Book[]
            {
                new Book("Winnie The Pooh", 1967, "A.A. Milne"),
                new Book("Under the Yoke", 1893, "Ivan Vazov"),
                new Book("TestBookTitile", 1111, "TestAuthorOne", "TestAuthorTwo")
            };

            Library myLibrary = new Library(books);

            foreach (Book book in myLibrary)
            {
                Console.WriteLine(book);
            }
        }
    }
}
