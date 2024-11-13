using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Telephony
{
    public class StationaryPhone : IStationaryPhone
    {
        public string Call(string number)
        {
            return $"Dialing... {number}";
        }
    }
}
