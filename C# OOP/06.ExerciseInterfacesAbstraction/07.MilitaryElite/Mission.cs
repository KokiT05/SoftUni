using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite
{
    internal class Mission : IMissions
    {
        public Mission(string codeName, string stateMission)
        {
            this.CodeName = codeName;
            this.State = stateMission;
        }
        public string CodeName { get; private set; }

        public string State { get; private set; }

        public void CompleteMission()
        {
            this.State = GlobalConstants.MissionStateFinished;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
