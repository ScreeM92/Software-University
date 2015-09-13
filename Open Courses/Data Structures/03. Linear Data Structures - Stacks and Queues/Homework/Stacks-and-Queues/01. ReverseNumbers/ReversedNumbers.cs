namespace _01.ReverseNumbers
{
    using System;
    using System.Collections.Generic;

    public class ReversedNumbers
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            var numbers = FillStackWithNumbers(input);

            PrintStack(numbers);
        }

        public static Stack<int> FillStackWithNumbers(string[] input)
        {
            var numbersStack = new Stack<int>();

            foreach (var number in input)
            {
                numbersStack.Push(int.Parse(number));
            }

            return numbersStack;
        }

        public static void PrintStack<T>(Stack<T> stack)
        {
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop() + " ");
            }
        }
    }
}