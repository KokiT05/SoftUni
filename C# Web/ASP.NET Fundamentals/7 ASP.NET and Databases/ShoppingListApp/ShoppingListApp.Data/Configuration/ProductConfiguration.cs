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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> model)
        {
            model.Property(p => p.Id);
            model.HasKey(p => p.Id);

            model.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(40)
                .HasComment("Product name");

            model.Property(p => p.Description)
                .HasMaxLength(100)
                .HasComment("Product description");

            model.Property(p => p.Price)
                .HasComment("Product price");

            //model.HasOne(p => p.ProductList)
            //    .WithMany(p => p.Products)
            //    .HasForeignKey(p => p.ProductListId);

            model.Property(p => p.ProductListId)
                .HasComment("Product list id");
        }
    }
}
