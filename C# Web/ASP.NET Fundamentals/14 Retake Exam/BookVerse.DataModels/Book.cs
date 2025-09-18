using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.DataModels
{
     public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? CoverImageUrl { get; set; }

        public string PublisherId { get; set; } = null!;

        public IdentityUser Publisher { get; set; } = null!;

        public DateTime PublishedOn { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;

        public ICollection<UserBook> UsersBooks { get; set; } = new HashSet<UserBook>();
    }
}
