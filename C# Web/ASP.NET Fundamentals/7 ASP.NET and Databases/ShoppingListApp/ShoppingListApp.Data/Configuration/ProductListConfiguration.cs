using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingListApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp.Data.Configuration
{
    public class ProductListConfiguration : IEntityTypeConfiguration<ProductList>
    {
        public void Configure(EntityTypeBuilder<ProductList> model)
        {
            model.HasKey(pl => pl.Id);
            model.Property(pl => pl.Id);

            model.Property(pl => pl.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasComment("Product list name");

            model.Property(pl => pl.Description)
                .HasMaxLength(300)
                .HasComment("Product list desctiption");

            model.Property(pl => pl.TotalPrice)
                .HasComment("Total price of all products");

            model.HasMany(pl => pl.Products)
                .WithOne(pl => pl.ProductList)
                .HasForeignKey(pl => pl.ProductListId);
        }
    }
}
