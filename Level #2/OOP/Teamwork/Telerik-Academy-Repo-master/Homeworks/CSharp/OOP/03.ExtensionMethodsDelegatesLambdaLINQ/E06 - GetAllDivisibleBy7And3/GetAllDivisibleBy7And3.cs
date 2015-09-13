using System;
using System.Linq;

class GetAllDivisibleBy7And3
{
    static void Main()
    {
        int[] numbers = {1, 23, 50, 21, 7, 3, 42, 84, 21, 33, 168};

        //With Lambda expression
        var getDivisible = numbers.Where(number => number % 3 == 0 && number % 7 == 0);

        foreach (var number in getDivisible)
        {
            Console.WriteLine(number);
        }
        Console.WriteLine();


        //With Linq
        var getDivisibleLinq = 
            from number in numbers
            where number % 3 == 0 && number % 7 == 0
            select number;

        foreach (var number in getDivisibleLinq)
        {
            Console.WriteLine(number);
        }

    }
}

