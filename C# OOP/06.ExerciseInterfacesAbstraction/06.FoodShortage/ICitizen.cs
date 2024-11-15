using _06.FoodShortage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace _05.BirthdayCelebrations
{
    public interface ICitizen : IPerson
    {
        string Id { get; set; }
        string Birthday { get; set; }
    }
}
