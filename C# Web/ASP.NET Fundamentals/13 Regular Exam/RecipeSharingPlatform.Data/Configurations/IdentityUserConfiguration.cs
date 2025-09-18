﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSharingPlatform.Data.Configurations
{
    public class IdentityUserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> IdentityUserModel)
        {
            IdentityUserModel.HasData(this.SeedDefaultUser());
        }

        private IdentityUser SeedDefaultUser()
        {
            IdentityUser defaultUser = new IdentityUser
            {
                Id = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                UserName = "admin@recipesharing.com",
                NormalizedUserName = "ADMIN@RECIPESHARING.COM",
                Email = "admin@recipesharing.com",
                NormalizedEmail = "ADMIN@RECIPESHARING.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
                    new IdentityUser { UserName = "admin@recipesharing.com" },
                    "Admin123!")
            };

            return defaultUser;
        }
    }
}
