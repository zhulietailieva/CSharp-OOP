using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    internal class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return Count == 0;

        }
        public Stack<string> AddRange (IEnumerable<string> items)
        {
            foreach (var item in items)
            {
                this.Push(item);
            }
            return this;
        }
        
    }
}
