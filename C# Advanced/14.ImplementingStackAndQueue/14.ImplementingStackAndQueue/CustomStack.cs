using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.ImplementingStackAndQueue
{
    public class CustomStack
    {
        private const int initialCapacity = 4;
        private int[] items;
        private int count;

        public CustomStack()
        {
            this.count = 0;
            this.items = new int[initialCapacity];
        }

        public int Count { get { return this.count; } }

        public void Push(int element)
        {
            if (this.items.Length == this.count)
            {
                Resize();
            }

            this.items[this.count] = element;
            this.count++;
        }

        public int Pop()
        {
            Validate();

            int lastIndex = this.count - 1;
            int lastValue = this.items[lastIndex];
            this.items[lastIndex] = default(int);
            this.count--;

            if (this.items.Length / 4 == this.count)
            {
                Shrink();
            }

            return lastValue;
        }

        public int Peek()
        {
            Validate();

            int lastValue = this.items[this.count - 1];

            return lastValue;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = this.count - 1; i >= 0; i--)
            {
                action(this.items[i]);
            }
        }

        public void MySelect(Func<int, int> func)
        {
            for (int i = this.count - 1; i >= 0; i--)
            {
                this.items[i] = func(this.items[i]);
                //int element = this.items[i];
                //int result = func(element);
                //this.items[i] = result;
            }
        }

        private void Validate()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty!");
            }
        }

        private void Shrink()
        {
            int[] copy = new int[this.items.Length / 2];
            Array.Copy(this.items, copy, this.count);
            this.items = copy;
        }

        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];
            Array.Copy(this.items, copy, this.count);
            this.items = copy;
        }
    }
}
