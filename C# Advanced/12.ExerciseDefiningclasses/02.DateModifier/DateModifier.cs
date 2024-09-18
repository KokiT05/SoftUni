using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.DateModifier
{
    public class DateModifier
    {
        private int days;

        public DateModifier()
        {
            
        }

        public int Days { get; set; }

        public double GetDaysBetween(string firstDate, string secondDate)
        {
            DateTime firstDateTime = DateTime.Parse(firstDate);
            DateTime seondDateTime = DateTime.Parse(secondDate);

            double differenceDays = Math.Abs((firstDateTime - seondDateTime).TotalDays);
            return differenceDays;
        }
    }
}
