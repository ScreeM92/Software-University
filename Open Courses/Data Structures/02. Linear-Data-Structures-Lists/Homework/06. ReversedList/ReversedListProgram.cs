namespace _06.ReversedList
{
    using System;

    public class ReversedListProgram
    {
        public static void Main()
        {
            var reversedList = new ReversedList<int>(4);
            reversedList.Add(1);
            reversedList.Add(2);
            reversedList.Add(3);
            reversedList.Add(4);
            // current list items are [4 3 2 1]

            // capacity will grow twice (8) then add 5
            reversedList.Add(5);
            // current list items are [5 4 3 2 1]

            Console.WriteLine("Current list");
            PrintList(reversedList);
            
            reversedList.Remove(4); // remove element at index 4 -> value 1
            // current list items are [5 4 3 2]

            Console.WriteLine("\nRemove element at index 4");
            PrintList(reversedList);

            Console.WriteLine("\nChange value = 10 of index 1");
            reversedList[1] = 10; // change value = 10 of index 1
            PrintList(reversedList);

            Console.WriteLine("\ncount: {0}", reversedList.Count);
            Console.WriteLine("capacity: {0}", reversedList.Capacity);
        }

        public static void PrintList(ReversedList<int> reversedList)
        {
            int i = 0;

            // test IEnumerable<T> 
            foreach (var item in reversedList)
            {
                Console.WriteLine("{0} -> {1}", i, item);
                i++;
            }
        }
    }
}