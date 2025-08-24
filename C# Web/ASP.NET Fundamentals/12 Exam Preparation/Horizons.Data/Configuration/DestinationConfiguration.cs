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
    using static GCommon.ValidationConstatnts.DestinationConstants;
    public class DestinationConfiguration : IEntityTypeConfiguration<Destination>
    {

        public void Configure(EntityTypeBuilder<Destination> model)
        {
            model.HasKey(d => d.Id);

            model.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            model.Property(d => d.Description)
                .IsRequired()
                .HasMaxLength(DescriptionMaxLength);

            model.Property(d => d.ImageUrl)
                .IsRequired(false);

            //model.Property(d => d.PublisherId)
            //    .IsRequired();

            model.HasOne(d => d.Publisher)
                .WithMany()
                .HasForeignKey(d => d.PublisherId)
                .OnDelete(DeleteBehavior.Cascade);

            model.Property(d => d.PublishedOn)
                .IsRequired();

            //model.Property(d => d.TerrainId)
            //    .IsRequired();

            model.HasOne(d => d.Terrain)
                .WithMany(t => t.Destinations)
                .HasForeignKey(d => d.TerrainId)
                .OnDelete(DeleteBehavior.Restrict);

            model.Property(d => d.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            model.HasData(this.SeedDestinations());
        }

        private List<Destination> SeedDestinations()
        {
            List<Destination> destinations = new List<Destination>()
            {
                    new Destination
                    {
                        Id = 1,
                        Name = "Rila Monastery",
                        Description = "A stunning historical landmark nestled in the Rila Mountains.",
                        ImageUrl = "https://img.etimg.com/thumb/msid-112831459,width-640,height-480,imgsize-2180890,resizemode-4/rila-monastery-bulgaria.jpg",
                        PublisherId = "7699db7d-964f-4782-8209-d76562e0fece",
                        PublishedOn = DateTime.Now,
                        TerrainId = 1,
                        IsDeleted = false
                    },
                    new Destination
                    {
                        Id = 2,
                        Name = "Durankulak Beach",
                        Description = "The sand at Durankulak Beach showcases a pristine golden color, creating a beautiful contrast against the azure waters of the Black Sea.",
                        ImageUrl = "https://travelplanner.ro/blog/wp-content/uploads/2023/01/durankulak-beach-1-850x550.jpg.webp",
                        PublisherId = "7699db7d-964f-4782-8209-d76562e0fece",
                        PublishedOn = DateTime.Now,
                        TerrainId = 2,
                        IsDeleted = false
                    },
                    new Destination
                    {
                        Id = 3,
                        Name = "Devil's Throat Cave",
                        Description = "A mysterious cave located in the Rhodope Mountains.",
                        ImageUrl = "https://detskotobnr.binar.bg/wp-content/uploads/2017/11/Diavolsko_garlo_17.jpg",
                        PublisherId = "7699db7d-964f-4782-8209-d76562e0fece",
                        PublishedOn = DateTime.Now,
                        TerrainId = 7,
                        IsDeleted = false
                    }
            };

            return destinations;
        }
    }
}
