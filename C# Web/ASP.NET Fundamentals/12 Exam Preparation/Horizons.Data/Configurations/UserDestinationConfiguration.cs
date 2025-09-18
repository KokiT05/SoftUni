using Horizons.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.Data.Configuration
{
    public class UserDestinationConfiguration : IEntityTypeConfiguration<UserDestination>
    {
        public void Configure(EntityTypeBuilder<UserDestination> model)
        {
            model.HasKey(ud => new { ud.UserId, ud.DestinationId });

            model.HasQueryFilter(ud => ud.Destination.IsDeleted == false);

            model.HasOne(ud => ud.User)
                .WithMany()
                .HasForeignKey(ud => ud.UserId);
            //.OnDelete(DeleteBehavior.Cascade);

            model.HasOne(ud => ud.Destination)
                .WithMany(d => d.UsersDestinations)
                .HasForeignKey(ud => ud.DestinationId);
                //.OnDelete(DeleteBehavior.Restrict);
        }
    }
}
