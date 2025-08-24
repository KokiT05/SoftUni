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
    using static GCommon.ValidationConstatnts.TerrainConstants;
    public class TerrainConfiguration : IEntityTypeConfiguration<Terrain>
    {
        public void Configure(EntityTypeBuilder<Terrain> model)
        {
            model.HasKey(t => t.Id);

            model.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            //model.HasMany(t => t.Destinations);

            model.HasData(this.SeedTerrains());
        }

        private List<Terrain> SeedTerrains()
        {
            List<Terrain> terrains = new List<Terrain>()
            {
                new Terrain { Id = 1, Name = "Mountain" },
                new Terrain { Id = 2, Name = "Beach" },
                new Terrain { Id = 3, Name = "Forest" },
                new Terrain { Id = 4, Name = "Plain" },
                new Terrain { Id = 5, Name = "Urban" },
                new Terrain { Id = 6, Name = "Village" },
                new Terrain { Id = 7, Name = "Cave" },
                new Terrain { Id = 8, Name = "Canyon" }
            };

            return terrains;
        }
    }
}
