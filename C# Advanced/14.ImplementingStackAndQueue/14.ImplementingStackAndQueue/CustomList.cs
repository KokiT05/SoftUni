using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.ImplementingStackAndQueue
{
    public class CustomList
    {
        private const int InitialCapacity = 2;
        private int[] items;

        public CustomList()
        {
            this.items = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return items[index];
            }

            set
            {
                this.ValidateIndex(index);
                items[index] = value;
            }
        }

        public void Add(int item)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count] = item;

            this.Count++;
        }

        public int RemoveAt(int index)
        {
            this.ValidateIndex(index);

            int item = this.items[index];
            this.items[index] = default(int);
            this.Shift(index);
            this.Count--;

            if (this.Count == this.items.Length / 4)
            {
                this.Shrink();
            }

            return item;
        }

        public void Insert(int index, int element)
        {
            if (index > this.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid index!");
            }

            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.ShiftTiRight(index);
            this.items[index] = element;
            this.Count++;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i] == element)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            this.ValidateIndex(firstIndex);
            this.ValidateIndex(secondIndex);

            int value = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = value;
        }

        public int Find(Predicate<int> func)
        {
            bool flag = false;
            for (int i = 0; i < this.Count; i++)
            {
                flag = func(this.items[i]);
                if (flag)
                {
                    return this.items[i];
                }
            }

            return 0;
        }

        public void Reverse()
        {
            int[] reverseList = new int[this.Count];
            int count = 0;
            for (int i = this.Count - 1; i >= 0; i--)
            {
                reverseList[count] = this.items[i];
                count++;
            }

            this.items = reverseList;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < this.Count; i++)
            {
                stringBuilder.Append(this.items[i]);
                stringBuilder.Append(" ");
            }

            return stringBuilder.ToString();
        }

        private void ValidateIndex(int index)
        {
            if (index >= this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }
        private void Shift(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default(int);
        }

        private void Shrink()
        {
            int[] copy = new int[this.items.Length / 2];
            Array.Copy(this.items, copy, this.Count);
            //for (int i = 0; i < this.Count; i++)
            //{
            //    copy[i] = this.items[i];
            //}

            this.items = copy;
        }

        public void ShiftTiRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }
    }
}
