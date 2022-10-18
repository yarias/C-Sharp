using System;
namespace CSharpIntermidiate.inheritance_examples
{
    public class Stack
    {
        private readonly List<Object> _stack = new List<Object>();

        public void Push(object obj)
        {
            if (Object.Equals(obj, null))
            {
                throw new InvalidOperationException("Null object cannot be stored in the Stack");
            }
            this._stack.Add(obj);
        }

        public Object Pop()
        {
            if (this._stack.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }
            int index = this._stack.Count - 1;
            var element = this._stack[index];
            this._stack.RemoveAt(index);
            return element;
        }

        public void Clear()
        {
            this._stack.Clear();
        }
    }
}

