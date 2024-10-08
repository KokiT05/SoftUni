

namespace _07.Tuple
{
    public class Tuple<TFirst, TSecond>
    {
        private TFirst itemOne;
        private TSecond itemTwo;
        public Tuple(TFirst itemOne, TSecond itemTwo)
        {
            this.ItemOne = itemOne;
            this.ItemTwo = itemTwo; 
        }

        public TFirst ItemOne { get; set; }

        public TSecond ItemTwo { get; set; }
    }
}
