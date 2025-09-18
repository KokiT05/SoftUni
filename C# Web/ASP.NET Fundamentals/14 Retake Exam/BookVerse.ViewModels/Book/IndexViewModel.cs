using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookVerse.GCommon.ValidationConstants;

namespace BookVerse.ViewModels.Book
{
    public class IndexViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? CoverImageUrl { get; set; }

        public string GenreName { get; set; } = null!;

        public int SavedCount { get; set; }

        public bool IsAuthor { get; set; }

        public bool IsSaved { get; set; }
    }
}
