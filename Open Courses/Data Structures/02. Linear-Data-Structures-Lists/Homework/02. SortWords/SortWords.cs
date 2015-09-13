namespace _02.SortWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortWords
    {
        public static void Main()
        {
            IList<string> words = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .OrderBy(w => w)
                .ToList();

            Console.WriteLine(string.Join(" ", words));
        }
    }
}