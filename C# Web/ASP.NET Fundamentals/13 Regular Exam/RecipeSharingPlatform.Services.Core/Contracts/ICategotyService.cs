using RecipeSharingPlatform.ViewModels.Category;
using RecipeSharingPlatform.ViewModels.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSharingPlatform.Services.Core.Contracts
{
    public interface ICategotyService
    {
        Task<IEnumerable<AllCategoriesViewModel>> GetAllCategories();
    }
}
