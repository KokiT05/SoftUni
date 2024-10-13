namespace _02.LibraryYield
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

            Library<Book> myLibrary = new Library<Book>(books);

            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
