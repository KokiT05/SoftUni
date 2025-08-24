using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.Web.ViewModels.Destination
{
    public class DeleteDestinationViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Publisher { get; set; } = null!;

        public string PublisherId { get; set; } = null!;
    }
}
