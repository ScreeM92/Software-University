namespace OrderedSet
{
    using System;
    using System.Collections.Generic;

    public class OrderedSetExamples
    {
        private const int ContainedValue = 12;
        private const int NotContainedValue = 200;
        private static readonly string Separator = new string('-', 70);

        public static void Main()
        {
            List<int> itemsToAdd = new List<int> { 17, 9, 9, 12, 19, 6, 25, 10, 15 };  

            var set = new OrderedSet<int>();

            Console.WriteLine("Adding elements: {0}", string.Join(", ", itemsToAdd));
            foreach (var item in itemsToAdd)
            {
                var added = set.Add(item);
                //// duplicate items shouldn't be added twice in the set like item 9
                Console.WriteLine("Item {0}\t: {1}", item, added ? "added" : "not added"); 
            }

            Console.WriteLine("{0}\nUsing IEnumerable foreach:", Separator);
            foreach (var element in set)
            {
                Console.WriteLine(element);
            }
            
            Console.WriteLine("{0}\nCount: {1}", Separator, set.Count);
            Console.WriteLine("{0}\nMin: {1}", Separator, set.Min);
            Console.WriteLine("{0}\nMax: {1}", Separator, set.Max);
            Console.WriteLine("{0}\nContains {1}: {2}", Separator, ContainedValue, set.Contains(ContainedValue));
            Console.WriteLine("{0}\nContains {1}: {2}", Separator, NotContainedValue, set.Contains(NotContainedValue));

            Console.WriteLine("{0}\nUsing ForEach method:", Separator);
            set.ForEach(Console.WriteLine);
            
            Console.WriteLine("{0}\nEfter removing 19:", Separator);
            set.Remove(19);
            set.ForEach(Console.WriteLine);
            Console.WriteLine("Count: {0}", set.Count);

            Console.WriteLine("{0}\nEfter removing all items:", Separator);
            set.Remove(6);
            set.Remove(9);
            set.Remove(15);
            set.Remove(25);
            set.Remove(10);
            set.Remove(12);
            set.Remove(17);
            Console.WriteLine("Count: {0}", set.Count);
            set.ForEach(Console.WriteLine); // Shouldn't print items because the set is empty
        }
    }
}