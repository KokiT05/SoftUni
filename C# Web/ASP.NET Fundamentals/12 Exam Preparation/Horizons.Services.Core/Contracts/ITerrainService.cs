using Horizons.Web.ViewModels.Terrain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.Services.Core.Contracts
{
    public interface ITerrainService
    {
        Task<IEnumerable<SelectListTerrainViewModel>> GetSelectListTerrainAsync();
    }
}
