using System;

namespace _03.ArrayStack
{
    using System.Collections.Generic;

    public class ArrayStackProgram
    {
        public static void Main()
        {
            var arrayStack = new ArrayStack<int>();
            arrayStack.Push(2);
            arrayStack.Push(-4);
            arrayStack.Push(13);
            arrayStack.Push(22);
            arrayStack.Push(30);

            Console.WriteLine("Count: {0}", arrayStack.Count);
            Console.WriteLine("Capacity: {0}", arrayStack.Capacity);

            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            var arr = stack.ToArray();

            Console.WriteLine(string.Join(", ", arr));
        } 
    }
}