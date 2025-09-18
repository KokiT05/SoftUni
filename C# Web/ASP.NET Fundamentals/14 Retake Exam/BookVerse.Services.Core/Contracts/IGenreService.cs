using BookVerse.ViewModels.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Services.Core.Contracts
{
    public interface IGenreService
    {
        Task<IEnumerable<AddBookGenreDropDownModel>> GetAllGenresAsync();
    }
}
