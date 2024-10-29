using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public Stack<string> AddRange(params string[] strings)
        {
            for (int i = 0; i < strings.Length; i++)
            {
                this.Push(strings[i]);
            }

            return this;
        }
    }
}
