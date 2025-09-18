using BookVerse.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Data.Configuration
{
    using static GCommon.ValidationConstants.Genre;
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> model)
        {
            model.HasKey(g => g.Id);

            model.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(GenreNameMaxLength);

            model.HasData(this.GenerateSeedGenres());
        }

        private List<Genre> GenerateSeedGenres()
        {
            List<Genre> genres = new List<Genre>()
            {
                    new Genre { Id = 1, Name = "Fantasy" },
                    new Genre { Id = 2, Name = "Thriller" },
                    new Genre { Id = 3, Name = "Romance" },
                    new Genre { Id = 4, Name = "Sci‑Fi" },
                    new Genre { Id = 5, Name = "History" },
                    new Genre { Id = 6, Name = "Non‑Fiction" }
                
            };

            return genres;
        }
    }
}
