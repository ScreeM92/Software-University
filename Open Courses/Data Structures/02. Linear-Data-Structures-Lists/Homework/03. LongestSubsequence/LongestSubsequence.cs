namespace _03.LongestSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestSubsequence
    {
        public static void Main()
        {
            IList<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Console.WriteLine(string.Join(" ", GetLongstSubsequence(numbers)));
        }

        public static IList<int> GetLongstSubsequence(IList<int> numbers)
        {
            IList<int> longestSequence = new List<int>();

            if (numbers.Any())
            {
                longestSequence = numbers
                    .Select((n, i) => new { Value = n, Index = i })
                    .OrderBy(s => s.Value)
                    .Select((o, i) => new { o.Value, Diff = i - o.Index })
                    .GroupBy(s => new { s.Value, s.Diff })
                    .OrderByDescending(g => g.Count())
                    .First()
                    .Select(f => f.Value)
                    .ToList();
            }

            return longestSequence;
        } 
    }
}