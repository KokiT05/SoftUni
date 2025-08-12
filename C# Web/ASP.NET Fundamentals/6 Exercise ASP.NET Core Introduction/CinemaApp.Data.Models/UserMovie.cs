using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Models
{
    [Comment("User Watchlist entry in the system.")]
    public class UserMovie
    {
        [Comment("Foreign key to the referenced AspNetUser. Part of the entity composite PK.")]
        public string UserId { get; set; } = null!;

        public virtual IdentityUser User { get; set; } = null!;

        [Comment("Foreign key to the referenced Movie. Part of the entity composite PK.")]
        public Guid MovieId { get; set; }

        public virtual Movie Movie { get; set; } = null!;

        [Comment("Show if UserMovie entry is deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
