using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.ViewModels.Book
{
    using static GCommon.ValidationConstants.Book;
    public class EditBookViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(BookTitleMinLength)]
        [MaxLength(BookTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(BookDescriptionMinLength)]
        [MaxLength(BookDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public string? CoverImageUrl { get; set; }

        [Required]

        public DateTime PublishedOn { get; set; }
        public int GenreId { get; set; }

        public IEnumerable<AddBookGenreDropDownModel> Genres { get; set; } = new List<AddBookGenreDropDownModel>();

        
    }
}
