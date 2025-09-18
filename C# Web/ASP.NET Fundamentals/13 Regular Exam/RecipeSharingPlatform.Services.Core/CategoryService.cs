using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipeSharingPlatform.Data;
using RecipeSharingPlatform.Data.Models;
using RecipeSharingPlatform.Services.Core.Contracts;
using RecipeSharingPlatform.ViewModels.Category;
using RecipeSharingPlatform.ViewModels.Recipe;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSharingPlatform.Services.Core
{
    using static GCommon.ValidationConstants.RecipeConstants;
    public class CategoryService : ICategotyService
    {
        private readonly ApplicationDbContext dbContext;
        public CategoryService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllCategoriesViewModel>> GetAllCategories()
        {
            IEnumerable<AllCategoriesViewModel> allCategories = await this.dbContext
                                                                        .Categories
                                                                        .Select(c => new AllCategoriesViewModel()
                                                                        {
                                                                            Id = c.Id,
                                                                            Name = c.Name,
                                                                        })
                                                                        .ToListAsync();

            return allCategories;
        }
    }
}
