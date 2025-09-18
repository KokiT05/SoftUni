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
    public class UserBookConfiguration : IEntityTypeConfiguration<UserBook>
    {
        public void Configure(EntityTypeBuilder<UserBook> model)
        {
            model.HasKey(ub => new {ub.UserId, ub.BookId});

            model.HasQueryFilter(ub => ub.Book.IsDeleted == false);

            model.HasOne(ub => ub.User)
                .WithMany()
                .HasForeignKey(ub => ub.UserId);

            model.HasOne(ub => ub.Book)
                .WithMany(b => b.UsersBooks)
                .HasForeignKey(ub => ub.BookId);
        }
    }
}
