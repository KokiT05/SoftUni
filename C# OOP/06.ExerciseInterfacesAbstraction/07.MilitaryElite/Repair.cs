﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite
{
    internal class Repair : IRepair
    {
        public Repair(string partName, int hour)
        {
            this.PartName = partName;
            this.Hours = hour;
        }
        public string PartName { get; private set; }

        public int Hours { get; private set; }

        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked {this.Hours}";
        }
    }
}
