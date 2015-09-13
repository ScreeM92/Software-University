using System;
using System.Collections.Generic;
using System.Linq;

class ListOfIntegers
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        numbers.Add(5);
        Console.WriteLine(numbers[0]); // 5
        
        Console.WriteLine();

        for (int i = 2; i <= 20; i+=2)
        {
            numbers.Add(i);
        }

        numbers.Sort();

        for (int i = 0; i < numbers.Count; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}
