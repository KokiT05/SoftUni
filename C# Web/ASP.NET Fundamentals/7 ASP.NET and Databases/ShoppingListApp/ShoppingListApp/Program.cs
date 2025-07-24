using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Data;
using ShoppingListApp.Services.Core;
using ShoppingListApp.Services.Core.Interfaces;

namespace ShoppingListApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnectionString' not found.");

            builder.Services.AddDbContext<ShoppingListDbContext>(options =>
            options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IProductListService, ProductListService>();
            builder.Services.AddScoped<IProductService, ProductService>();

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
