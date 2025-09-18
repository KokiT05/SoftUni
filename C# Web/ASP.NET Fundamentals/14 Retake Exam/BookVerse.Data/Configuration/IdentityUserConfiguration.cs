using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Data.Configuration
{
    public class IdentityUserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> model)
        {
            model.HasData(this.CreateDefaultAdmin());
        }

        private IdentityUser CreateDefaultAdmin()
        {
            IdentityUser defaultUser = new IdentityUser
            {
                Id = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                UserName = "admin@bookverse.com",
                NormalizedUserName = "ADMIN@BOOKVERSE.COM",
                Email = "admin@bookverse.com",
                NormalizedEmail = "ADMIN@BOOKVERSE.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>()
                    .HashPassword(new IdentityUser { UserName = "admin@bookverse.com" }, "Admin123!")
            };

            return defaultUser;
        }
    }
}
