using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private LinkedList<T> stack;
        //private List<T> items; // C

        //public CustomStack() // C
        //{
        //    this.items = new List<T>();
        //}

        //public CustomStack(List<T> items) // C
        //{
        //    this.items = new List<T>(items);
        //}

        //public void Push(T element) // C
        //{
        //    this.items.Add(element);
        //}

        //public T Pop()
        //{
        //    if (this.items.Count == 0)
        //    {
        //        throw new InvalidOperationException("No elements");
        //    }

        //    int index = this.items.Count - 1;
        //    T element = this.items[index];
        //    this.items.RemoveAt(index);
        //    return element;
        //}

        //public IEnumerator<T> GetEnumerator()
        //{
        //    for (int i = items.Count - 1; i >= 0; i--)
        //    {
        //        yield return items[i];
        //    }
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return this.GetEnumerator();
        //}

        public CustomStack(params T[] collection)
        {
            stack = new LinkedList<T>(collection);
        }

        public void Push(T item)
        {
            stack.AddLast(item);
        }

        public T Pop()
        {
            if (stack.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            T value = stack.Last();
            stack.RemoveLast();
            return value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> lastElement = stack.Last;
            while (lastElement != null)
            {
                yield return lastElement.Value;
                lastElement = lastElement.Previous;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
