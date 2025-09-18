using BookVerse.Services.Core.Contracts;
using BookVerse.ViewModels.Book;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookVerse.Web.Controllers
{
    using static GCommon.ValidationConstants.Book;
    public class BookController : BaseController
    {
        private readonly IBookService bookService;
        private readonly IGenreService genreService;
        public BookController(IBookService bookService, IGenreService genreService)
        {
            this.bookService = bookService;
            this.genreService = genreService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            string? userId = this.GetUserId();

            IEnumerable<IndexViewModel> books = await this.bookService.GetAllBooksAsync(userId);

            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                if (this.IsUserAuthenticated() == false)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                AddBookInputViewModel addBookInput = new AddBookInputViewModel()
                {
                    PublishedOn = DateTime.UtcNow.ToString(BookDateFormat),
                    Genres = await this.genreService.GetAllGenresAsync()
                };

                return this.View(addBookInput);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddBookInputViewModel addBookInput)
        {
            if (ModelState.IsValid == false)
            {
                addBookInput.Genres = await this.genreService.GetAllGenresAsync();
                return this.View(addBookInput);
            }

            try
            {

                string? userId = this.GetUserId()!;

                bool isSuccessfullyCreate = await this.bookService.CreateBookAsync(addBookInput, userId);

                if (isSuccessfullyCreate == false)
                {
                    this.ModelState.AddModelError(string.Empty, "Fatal error occurred while creating a book!");
                    return this.RedirectToAction(nameof(Index));
                }

                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> MyBooks()
        {
            if(this.IsUserAuthenticated() == false)
            {
                return this.RedirectToAction(nameof(Index));
            }

            string userId = this.GetUserId()!;

            IEnumerable<MyBooksViewModel> myBooks = await this.bookService.GetAllMyBooksAsync(userId);
            return this.View(myBooks);
        }

        [HttpPost]
        public async Task<IActionResult> AddToMyBooks(int id)
        {
            if (this.IsUserAuthenticated() == false)
            {
                return this.RedirectToAction(nameof(Index));
            }

            try
            {
                string userId = this.GetUserId()!;

                bool isAddSuccessfully = await this.bookService.AddBookMyBookCollectionAsync(id, userId);

                if (isAddSuccessfully == false)
                {
                    this.ModelState.AddModelError(string.Empty, "Fatal error occured while adding a book in MyBooks!");
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            if (this.IsUserAuthenticated() == false)
            {
                return this.RedirectToAction(nameof(Index));
            }

            try
            {
                string userId = this.GetUserId()!;
                bool isBookRemoveSuccessfully = await this.bookService.RemoveBookMyBookCollectionAsync(id, userId);

                if (isBookRemoveSuccessfully == false)
                {
                    this.ModelState.AddModelError(string.Empty, "Fatal error occurred while removing a book from MyBooks collection.");
                    return this.RedirectToAction(nameof(MyBooks));
                }

                return this.RedirectToAction(nameof(MyBooks));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(MyBooks));
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                string? userId = this.GetUserId();

                DetailsBookViewModel? detailsBook = await this.bookService.GetDetailsBookAsync(id, userId);

                if (detailsBook == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                return this.View(detailsBook);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (this.IsUserAuthenticated() == false)
            {
                return this.RedirectToAction(nameof(Index));
            }

            string userId = this.GetUserId()!;
            EditBookViewModel? editBook = await this.bookService.GetEditBookAsync(id, userId);

            if (editBook == null)
            {
                return this.RedirectToAction(nameof(Details), new { id = id});
            }

            editBook.Genres = await this.genreService.GetAllGenresAsync();

            return this.View(editBook);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditBookViewModel editBook)
        {
            if (ModelState.IsValid == false)
            {
                editBook.Genres = await this.genreService.GetAllGenresAsync();
                return this.View(editBook);
            }

            try
            {
                string userId = this.GetUserId()!;

                bool isEditSuccessfully = await this.bookService.EditBookAsync(editBook, userId);

                if (isEditSuccessfully == false)
                {
                    this.ModelState.AddModelError(string.Empty, "Fatal error occurred while editing book!");
                    return this.RedirectToAction(nameof(Details), new { id = editBook.Id });
                }

                return this.RedirectToAction(nameof(Details), new { id = editBook.Id });

            }
            catch (Exception e)
            {
                Console.WriteLine( e.Message);
                
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (this.IsUserAuthenticated() == false)
            {
                return this.RedirectToAction(nameof(Index));
            }

            try
            {
                string userId = this.GetUserId()!;
                DeleteBookViewModel? deleteBook = await this.bookService.GetDeleteBookAsync(id, userId);

                if (deleteBook == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.View(deleteBook);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            try
            {
                string userId = this.GetUserId()!;
                bool isSuccessfully = await this.bookService.SoftDeleteBook(id, userId);

                if (isSuccessfully == false)
                {
                    this.ModelState.AddModelError(string.Empty, "Fatal error occurred while delete a book!");
                    return this.RedirectToAction(nameof(Index));
                }

                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Index));
            }
        }
    }
}
