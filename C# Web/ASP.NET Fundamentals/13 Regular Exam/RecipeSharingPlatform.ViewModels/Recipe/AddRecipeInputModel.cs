using RecipeSharingPlatform.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSharingPlatform.ViewModels.Recipe
{
    using static GCommon.ValidationConstants.RecipeConstants;
    public class AddRecipeInputModel
    {
        [Required]
        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        public virtual IEnumerable<AllCategoriesViewModel>? Categories { get; set; }

        [Required]
        [MinLength(InstructionsMinLength)]
        [MaxLength(InstructionsMaxLength)]
        public string Instructions { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required]
        public string CreatedOn { get; set; } = null!;

    }
}
