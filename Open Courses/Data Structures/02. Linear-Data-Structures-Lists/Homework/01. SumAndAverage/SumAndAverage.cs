namespace _01.SumAndAverage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumAndAverage
    {
        public static void Main()
        {
            IList<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var sum = numbers.Any() ? numbers.Sum() : 0;
            var average = numbers.Any() ? numbers.Average() : 0;
            
            Console.WriteLine("Sum={0}; Average={1:0.##}", sum, average);
        }
    }
}