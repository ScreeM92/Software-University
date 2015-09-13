using System;

class Program
{
    static void Main()
    {
        decimal[] numbers = { 1, 8, -5, 13, 7, 3, 2, 4, 1, 3, 4 };
        
        Console.WriteLine(numbers.Sum<decimal>());
        Console.WriteLine(numbers.Product<decimal>());
        Console.WriteLine(numbers.Min<decimal>());
        Console.WriteLine(numbers.Max<decimal>());
        Console.WriteLine(numbers.Average<decimal>());
        //Console.WriteLine(numbers.Min<short>());
        
    }
}

