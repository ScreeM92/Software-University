namespace _05.CountOfOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountOfOccurences
    {
        public static void Main()
        {
            IList<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var occurences = numbers
                .Select(v => new { Value = v, Count = numbers.Count(n => v == n) })
                .Distinct()
                .OrderBy(x => x.Value)
                .ToList();

            occurences.ForEach(o => { Console.WriteLine("{0} -> {1} times", o.Value, o.Count); });
        }
    }
}