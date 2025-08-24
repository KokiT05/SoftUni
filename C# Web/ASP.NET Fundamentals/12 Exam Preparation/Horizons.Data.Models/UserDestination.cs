﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizons.Data.Models
{
    public class UserDestination
    {
        public string UserId { get; set; } = null!;

        public IdentityUser User { get; set; } = null!;

        public int DestinationId { get; set; }

        public Destination Destination { get; set; } = null!;
    }
}
