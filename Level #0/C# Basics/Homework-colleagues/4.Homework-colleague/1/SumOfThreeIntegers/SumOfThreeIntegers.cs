using System;

class SumOfThreeIntegers
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Enter third number: ");
        int c = int.Parse(Console.ReadLine());

        Console.WriteLine("The sum is: " + (a + b + c));
    }
}
