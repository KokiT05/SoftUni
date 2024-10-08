using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Threeuple
{
    public class Threeuple<TFirstItem, TSecondItem, TThirdItem>
    {
        private TFirstItem itemOne;
        private TSecondItem itemTwo;
        private TThirdItem itemThird;
        public Threeuple(TFirstItem itemOne, TSecondItem itemTwo, TThirdItem itemThird)
        {
            this.ItemOne = itemOne;
            this.ItemTwo = itemTwo;
            this.ItemThird = itemThird;
        }

        public TFirstItem ItemOne { get; set; }

        public TSecondItem ItemTwo { get; set; }
        public TThirdItem ItemThird { get; set; }
    }
}
