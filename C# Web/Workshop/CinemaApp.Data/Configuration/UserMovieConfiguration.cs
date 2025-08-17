using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Configuration
{
    public class UserMovieConfiguration : IEntityTypeConfiguration<UserMovie>
    {
        public void Configure(EntityTypeBuilder<UserMovie> model)
        {
            model.HasKey(um => new { um.UserId, um.MovieId });

            model.Property(um => um.UserId).IsRequired();

            model.Property(um => um.IsDeleted).HasDefaultValue(false);

            model.HasOne(um => um.User)
                .WithMany()
                .HasForeignKey(um => um.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            model.HasOne(um => um.Movie)
                .WithMany(m => m.UserMovies)
                .HasForeignKey(um => um.MovieId)
                .OnDelete(DeleteBehavior.Restrict);

            model.HasQueryFilter(um => um.Movie.IsDeleted == false); 

            model.HasQueryFilter(um => um.IsDeleted == false);

        }
    }
}
