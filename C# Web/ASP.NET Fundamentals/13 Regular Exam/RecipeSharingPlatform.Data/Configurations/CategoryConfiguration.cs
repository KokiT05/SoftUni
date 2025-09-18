using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeSharingPlatform.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSharingPlatform.Data.Configurations
{
    using static GCommon.ValidationConstants.CategoryConstants;
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> categoryModel)
        {
            categoryModel.HasKey(c => c.Id);

            categoryModel.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            categoryModel.HasData(this.SeedCategory());
        }

        private List<Category> SeedCategory()
        {
            List<Category> categories = new List<Category>()
            {
                    new Category { Id = 1, Name = "Appetizer" },
                    new Category { Id = 2, Name = "Main Dish" },
                    new Category { Id = 3, Name = "Dessert" },
                    new Category { Id = 4, Name = "Soup" },
                    new Category { Id = 5, Name = "Salad" },
                    new Category { Id = 6, Name = "Beverage" }
            };

            return categories;
        }
    }
}
