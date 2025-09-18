using BookVerse.ViewModels.Book;

namespace BookVerse.Services.Core.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<IndexViewModel>> GetAllBooksAsync(string? userId);

        Task<bool> CreateBookAsync(AddBookInputViewModel inputModel, string userId);

        Task<IEnumerable<MyBooksViewModel>> GetAllMyBooksAsync(string userId);

        Task<bool> AddBookMyBookCollectionAsync(int? bookId, string? userId);

        Task<bool> RemoveBookMyBookCollectionAsync(int bookId, string userId);

        Task<DetailsBookViewModel?> GetDetailsBookAsync(int bookId, string? userId);

        Task<EditBookViewModel?> GetEditBookAsync(int bookId, string userId);

        Task<bool> EditBookAsync(EditBookViewModel inputEditBook, string userId);

        Task<DeleteBookViewModel?> GetDeleteBookAsync(int bookId, string userId);

        Task<bool> SoftDeleteBook(int bookId, string userId);
    }
}
