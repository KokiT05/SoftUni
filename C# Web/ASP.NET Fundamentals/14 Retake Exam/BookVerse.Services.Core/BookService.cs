using BookVerse.Data;
using BookVerse.DataModels;
using BookVerse.Services.Core.Contracts;
using BookVerse.ViewModels.Book;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Globalization;

namespace BookVerse.Services.Core
{
    using static GCommon.ValidationConstants.Book;
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly UserManager<IdentityUser> userManager;
        public BookService(ApplicationDbContext applicationDbContext, UserManager<IdentityUser> userManager)
        {
            this.applicationDbContext = applicationDbContext;
            this.userManager = userManager;
        }

        public async Task<IEnumerable<IndexViewModel>> GetAllBooksAsync(string? userId)
        {

            bool isNullUserId = string.IsNullOrEmpty(userId);

            IEnumerable<IndexViewModel> allBooks = await this.applicationDbContext
                                                            .Books
                                                            .Include(b => b.Genre)
                                                            .Include(b => b.UsersBooks)
                                                            .AsNoTracking()
                                                            .Select(b => new IndexViewModel()
                                                            {
                                                                Id = b.Id,
                                                                Title = b.Title,
                                                                CoverImageUrl = b.CoverImageUrl,
                                                                GenreName = b.Genre.Name,
                                                                SavedCount = b.UsersBooks.Count,
                                                                IsAuthor = isNullUserId == false ?
                                                                    b.PublisherId.ToLower() == userId!.ToLower() : false,
                                                                IsSaved = isNullUserId == false ?
                                                                    b.UsersBooks.Any(ub => ub.UserId.ToLower() == userId!.ToLower()) : false

                                                            }).ToListAsync();

            return allBooks;
        }

        public async Task<bool> CreateBookAsync(AddBookInputViewModel inputModel, string userId)
        {
            bool result = false;

            Genre? genre = await this.applicationDbContext.Genres.FindAsync(inputModel.GenreId);
            //string date = DateTime.ParseExact(inputModel.PublishedOn, BookDateFormat, CultureInfo.InvariantCulture).ToString();
            if ((await this.IsUserExist(userId)) && (genre != null))
            {
                Book book = new Book()
                {
                    Title = inputModel.Title,
                    Description = inputModel.Description,
                    PublishedOn = DateTime.ParseExact(inputModel.PublishedOn, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    GenreId = inputModel.GenreId,
                    PublisherId = userId,
                    CoverImageUrl = inputModel.CoverImageUrl,

                };

                result = true;

                await this.applicationDbContext.Books.AddAsync(book);
                await this.applicationDbContext.SaveChangesAsync();
            }

            return result;
        }

        public async Task<IEnumerable<MyBooksViewModel>> GetAllMyBooksAsync(string userId)
        {
            IEnumerable<MyBooksViewModel> allMyBooks = await this.applicationDbContext
                                                            .UsersBooks
                                                            .AsNoTracking()
                                                            .Include(ub => ub.Book)
                                                            .Include(ub => ub.Book.Genre)
                                                            .Where(ub => ub.UserId.ToLower() == userId.ToLower())
                                                            .Select(ub => new MyBooksViewModel()
                                                            {
                                                                Id = ub.BookId,
                                                                Title = ub.Book.Title,
                                                                CoverImageUrl = ub.Book.CoverImageUrl,
                                                                Genre = ub.Book.Genre.Name

                                                            }).ToListAsync();

            return allMyBooks;
        }

        public async Task<bool> AddBookMyBookCollectionAsync(int? bookId, string? userId)
        {
            Book? book = await this.applicationDbContext.Books.FindAsync(bookId);

            if (book == null || userId == null)
            {
                return false;
            }

            bool isInMyBooks = await this.applicationDbContext
                                                .UsersBooks
                                                .AsNoTracking()
                                                .AnyAsync(ub => ub.UserId.ToLower() == userId && ub.BookId == bookId);
            if (isInMyBooks)
            {
                return false;
            }

            UserBook userBook = new UserBook()
            {
                UserId = userId,
                BookId = book.Id,
            };

            await this.applicationDbContext.UsersBooks.AddAsync(userBook);
            await this.applicationDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoveBookMyBookCollectionAsync(int bookId, string userId)
        {
            bool result = false;

            Book? book = await this.applicationDbContext.Books.FindAsync(bookId);
            if ((book != null) && (await this.IsUserExist(userId)))
            {
                UserBook? userBook = await this.applicationDbContext.UsersBooks.FindAsync([userId, bookId]);

                if (userBook != null)
                {

                    this.applicationDbContext.UsersBooks.Remove(userBook);
                    await this.applicationDbContext.SaveChangesAsync();

                    result = true;
                }
            }

            return result;
        }

        public async Task<DetailsBookViewModel?> GetDetailsBookAsync(int bookId, string? userId)
        {
            DetailsBookViewModel? bookDetails = await this.applicationDbContext.Books
                                                    .Include(b => b.Genre)
                                                    .Include(b => b.Publisher)
                                                    .Include(b => b.UsersBooks)
                                                    .Where(b => b.Id == bookId)
                                                    .Select(b => new DetailsBookViewModel()
                                                    {
                                                        Id = b.Id,
                                                        Title = b.Title,
                                                        CoverImageUrl = b.CoverImageUrl,
                                                        Description = b.Description,
                                                        PublishedOn = b.PublishedOn,
                                                        Publisher = b.Publisher.UserName,
                                                        Genre = b.Genre.Name,
                                                        IsAuthor = userId != null ? 
                                                                    b.PublisherId.ToLower() == userId.ToLower() :
                                                                    false,
                                                        IsSaved = userId != null ?
                                                                    b.UsersBooks.Any(ub => ub.UserId.ToLower() == userId.ToLower()) :
                                                                    false
                                                    }).FirstOrDefaultAsync();

            return bookDetails;
        }

        public async Task<EditBookViewModel?> GetEditBookAsync(int bookId, string userId)
        {
            EditBookViewModel? editBook = null;

            Book? book = await this.applicationDbContext.Books.Where(b => b.Id == bookId).FirstOrDefaultAsync();
            string bookPublisherId = book.PublisherId;

            if (bookPublisherId.ToLower() == userId.ToLower())
            {
                editBook = await this.applicationDbContext.Books.AsNoTracking()
                                                        .Where(b => b.Id == bookId)
                                                        .Select(b => new EditBookViewModel()
                                                        {
                                                            Id = b.Id,
                                                            Title = b.Title,
                                                            CoverImageUrl = b.CoverImageUrl,
                                                            Description = b.Description,
                                                            PublishedOn = b.PublishedOn,
                                                            GenreId = b.GenreId,

                                                        })
                                                        .FirstOrDefaultAsync();
            }

            return editBook;
        }

        public async Task<bool> EditBookAsync(EditBookViewModel inputEditBook, string userId)
        {
            Book? book = await this.applicationDbContext.Books.FindAsync(inputEditBook.Id);

            if (book != null)
            {
                if (book.PublisherId.ToLower() == userId.ToLower())
                {
                    book.Title = inputEditBook.Title;
                    book.Description = inputEditBook.Description;
                    book.CoverImageUrl = inputEditBook.CoverImageUrl;
                    book.PublishedOn = inputEditBook.PublishedOn;
                    book.GenreId = inputEditBook.GenreId;

                    await this.applicationDbContext.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }

        public async Task<DeleteBookViewModel?> GetDeleteBookAsync(int bookId, string userId)
        {
            DeleteBookViewModel? deleteBook = null;

            Book? book = await this.applicationDbContext.Books
                                                        .AsNoTracking()
                                                        .Include(b => b.Publisher)
                                                        .Where(b => b.Id == bookId)
                                                        .FirstOrDefaultAsync();


            if (book != null && (book.PublisherId.ToLower() == userId.ToLower()))
            {
                deleteBook = new DeleteBookViewModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Publisher = book.Publisher.NormalizedUserName
                };
            }

            return deleteBook;
        }

        public async Task<bool> SoftDeleteBook(int bookId, string userId)
        {
            Book? book = await this.applicationDbContext.Books.FindAsync(bookId);

            if (book != null && book.PublisherId.ToLower() == userId.ToLower())
            {
                book.IsDeleted = true;

                await this.applicationDbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        private async Task<bool> IsUserExist(string userId)
        {
            bool result = false;

            IdentityUser? user = await this.userManager.FindByIdAsync(userId);

            if (user != null)
            {
                result = true;
            }

            return result;
        }
    }
}
