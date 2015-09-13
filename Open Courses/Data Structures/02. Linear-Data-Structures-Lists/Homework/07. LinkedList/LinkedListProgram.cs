namespace _07.LinkedList
{
    using System;

    public class LinkedListProgram
    {
        public static void Main()
        {
            var linkedList = new LinkedList<int>();
            linkedList.Add(5);
            linkedList.Add(7);
            linkedList.Add(3);
            linkedList.Add(3);
            linkedList.Add(2);

            Console.WriteLine("Current list:");
            PrintList(linkedList);

            Console.WriteLine("\nRemove element at index 1");
            linkedList.Remove(1); // remove element at index 1
            PrintList(linkedList);

            Console.WriteLine("\nFirst index of 3: {0}", linkedList.FirstIndexOf(3));
            Console.WriteLine("Last index of 3: {0}", linkedList.LastIndexOf(3));
            Console.WriteLine("First index of 100: {0}", linkedList.FirstIndexOf(100));
            Console.WriteLine("Last index of 100: {0}", linkedList.LastIndexOf(100));
            Console.WriteLine("List count: {0}", linkedList.Count);
        }

        public static void PrintList(LinkedList<int> linkedList)
        {
            int i = 0;

            // test IEnumerable<T>
            foreach (var item in linkedList)
            {
                Console.WriteLine("{0} -> {1}", i, item);
                i++;
            }
        }
    }
}