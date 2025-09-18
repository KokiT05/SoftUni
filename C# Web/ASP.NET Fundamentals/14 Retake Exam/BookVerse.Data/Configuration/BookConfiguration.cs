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
    using static GCommon.ValidationConstants.Book;
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> model)
        {
            model.HasKey(b => b.Id);

            model.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(BookTitleMaxLength);

            model.Property(b => b.Description)
                .IsRequired()
                .HasMaxLength(BookDescriptionMaxLength);

            model.Property(b => b.CoverImageUrl)
                .IsRequired(false);

            model.Property(b => b.PublisherId)
                .IsRequired();

            model.Property(b => b.PublishedOn)
                .IsRequired();

            model.Property(b => b.GenreId)
                .IsRequired();

            model.Property(b => b.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            model.HasQueryFilter(b => b.IsDeleted == false);

            model.HasOne(b => b.Publisher)
                .WithMany()
                .HasForeignKey(b => b.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);

            model.HasOne(b => b.Genre)
                .WithMany(g => g.Books)
                .HasForeignKey(b => b.GenreId)
                .OnDelete(DeleteBehavior.Restrict);

            model.HasData(this.GenerateSeedBooks());
        }

        private List<Book> GenerateSeedBooks()
        {
            List<Book> books = new List<Book>()
            {
                    new Book
                    {
                        Id = 1,
                        Title = "Whispers of the Mountain",
                        Description = "Emily Harper (released 2015): A quiet village, a hidden path, and a choice that changes everything.",
                        CoverImageUrl = "https://m.media-amazon.com/images/I/9187Qn8bL6L._UF1000,1000_QL80_.jpg",
                        PublisherId = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                        PublishedOn = DateTime.Now,
                        GenreId = 1,
                        IsDeleted = false
                    },
                    new Book
                    {
                        Id = 2,
                        Title = "Shadows in the Fog",
                        Description = "Michael Turner (released: 2017): An investigator follows a trail of secrets through a city shrouded in mystery.",
                        CoverImageUrl = "https://m.media-amazon.com/images/I/719g0mh9f2L._UF1000,1000_QL80_.jpg",
                        PublisherId = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                        PublishedOn = DateTime.Now,
                        GenreId = 2,
                        IsDeleted = false
                    },
                    new Book
                    {
                        Id = 3,
                        Title = "Letters from the Heart",
                        Description = "Sarah Collins (released 2020): A touching story about love, distance, and the power of written words.",
                        CoverImageUrl = "https://m.media-amazon.com/images/I/71zwodP9GzL._UF1000,1000_QL80_.jpg",
                        PublisherId = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                        PublishedOn = DateTime.Now,
                        GenreId = 3,
                        IsDeleted = false
                    }
            };

            return books;
        }
    }
}
