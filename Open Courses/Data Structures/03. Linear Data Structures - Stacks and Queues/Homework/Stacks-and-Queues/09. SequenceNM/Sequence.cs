namespace _09.SequenceNM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Sequence
    {
        public static void Main()
        {
            Console.Write("Enter start and end numbers separated by a space: ");
            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var queue = new Queue<Item>();

            int start = input[0];
            int end = input[1];
            int shortestOperations = int.MaxValue;

            queue.Enqueue(new Item(start));

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.Depth > shortestOperations)
                {
                    break;
                }

                if ((current.Value < end && end >= 0 ) ||
                    (current.Value < 0 && end < 0))
                {
                    queue.Enqueue(new Item(current.Value + 1, current));
                    queue.Enqueue(new Item(current.Value + 2, current));
                    queue.Enqueue(new Item(current.Value * 2, current));
                }

                if (current.Value == end)
                {
                    PrintSequence(current);
                    shortestOperations = current.Depth;
                }
            }

            if (shortestOperations == int.MaxValue)
            {
                Console.WriteLine("(no solution)");
            }
        }

        public static void PrintSequence(Item item)
        {
            var numbers = new Stack<int>();

            while (item != null)
            {
                numbers.Push(item.Value);
                item = item.PreviousItem;
            }

            Console.WriteLine(string.Join(" -> ", numbers));
        }
    }
}