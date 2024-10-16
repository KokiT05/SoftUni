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
        LinkedList<T> stack;

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
