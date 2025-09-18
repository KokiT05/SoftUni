using BookVerse.Data;
using BookVerse.Services.Core.Contracts;
using BookVerse.ViewModels.Book;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Services.Core
{
    public class GenreService : IGenreService
    {
        private readonly ApplicationDbContext applicationDbContext;
        public GenreService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<IEnumerable<AddBookGenreDropDownModel>> GetAllGenresAsync()
        {
            IEnumerable<AddBookGenreDropDownModel> allGenres = await this.applicationDbContext
                                                                .Genres
                                                                .AsNoTracking()
                                                                .Select(g => new AddBookGenreDropDownModel()
                                                                {
                                                                    Id = g.Id,
                                                                    Name = g.Name,
                                                                }).ToListAsync();

            return allGenres;
        }
    }
}
