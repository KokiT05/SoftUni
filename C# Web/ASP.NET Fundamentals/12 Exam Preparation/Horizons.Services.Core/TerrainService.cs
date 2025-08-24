using Horizons.Data;
using Horizons.Services.Core.Contracts;
using Horizons.Web.ViewModels.Terrain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.Services.Core
{
    public class TerrainService : ITerrainService
    {
        private readonly ApplicationDbContext applicationDbContext;
        public TerrainService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<ICollection<SelectListTerrainViewModel>> GetSelectListTerrain()
        {
            ICollection<SelectListTerrainViewModel> selectListTerrain = await applicationDbContext.Terrains
                                                                        .AsNoTracking()
                                                                        .Select(t => new SelectListTerrainViewModel()
                                                                        {
                                                                            Id = t.Id,
                                                                            Name = t.Name,
                                                                        }).ToListAsync();

            return selectListTerrain;
        }
    }
}
