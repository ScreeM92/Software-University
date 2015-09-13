namespace _04.RemoveOddOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RemoveOddOccurences
    {
        public static void Main()
        {
            IList<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            
            var evenOccurences = numbers
                .Where(v => numbers.Count(n => v == n) % 2 == 0)
                .ToList();

            Console.WriteLine(string.Join(" ", evenOccurences));
        }
    }
}