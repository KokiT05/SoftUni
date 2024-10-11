

namespace _07.Tuple
{
    public class MyTuple<TFirst, TSecond>
    {
        private TFirst itemOne;
        private TSecond itemTwo;
        public MyTuple(TFirst itemOne, TSecond itemTwo)
        {
            this.ItemOne = itemOne;
            this.ItemTwo = itemTwo; 
        }

        public TFirst ItemOne { get; set; }

        public TSecond ItemTwo { get; set; }

        public override string ToString()
        {
            return $"{this.ItemOne} -> {this.ItemTwo}";
        }
    }
}
