using System;
using System.Linq;

class ArrayOfIntegers
{
    static void Main()
    {
        int[] numbers = new int[10];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i + 1;
        }

        numbers[3] = 20;
        numbers[5] = numbers[2] + numbers[7];

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine("numbers[{0}] = {1}", i, numbers[i]);
        }

        Console.WriteLine();

        Console.WriteLine("Sum = " + numbers.Sum());
        Console.WriteLine("Min = " + numbers.Min());
        Console.WriteLine("Max = " + numbers.Max());
        Console.WriteLine("First = " + numbers.First());
        Console.WriteLine("Last = " + numbers.Last());

        Console.WriteLine();

        Array.Sort(numbers);
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine("numbers[{0}] = {1}", i, numbers[i]);
        }
    }
}
