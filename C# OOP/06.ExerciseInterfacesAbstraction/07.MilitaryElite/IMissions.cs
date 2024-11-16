using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite
{
    public interface IMissions
    {
        string CodeName { get; }
        string State {  get; }

        void CompleteMission();
    }
}
