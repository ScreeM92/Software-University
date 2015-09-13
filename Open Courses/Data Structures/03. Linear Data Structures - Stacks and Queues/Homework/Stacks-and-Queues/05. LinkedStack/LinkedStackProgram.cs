namespace _05.LinkedStack
{
    using System;

    public class LinkedStackProgram
    {
        public static void Main()
        {
            var stack = new LinkedStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            var arr = stack.ToArray();
            Console.WriteLine(string.Join(", ", arr));
        } 
    }
}