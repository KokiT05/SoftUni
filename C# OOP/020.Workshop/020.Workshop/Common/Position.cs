﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020.Workshop.Common
{
    public class Position
    {
        public Position(int x, int y)
        {
            this.X = x; 
            this.Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
