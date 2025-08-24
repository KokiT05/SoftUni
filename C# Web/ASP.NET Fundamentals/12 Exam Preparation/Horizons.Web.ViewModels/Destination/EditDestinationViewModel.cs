using Horizons.Web.ViewModels.Terrain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.Web.ViewModels.Destination
{
    using static GCommon.ValidationConstatnts.DestinationConstants;
    public class EditDestinationViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public string PublishedOn {  get; set; } = null!;

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public ICollection<SelectListTerrainViewModel> Terrains { get; set; } = new List<SelectListTerrainViewModel>();

        [Required]
        public int TerrainId { get; set; }

        public string PublisherId { get; set; } = null!;
    }
}
