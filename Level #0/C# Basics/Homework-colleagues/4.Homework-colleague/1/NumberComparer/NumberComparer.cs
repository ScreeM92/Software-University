using System;

class NumberComparer
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        double b = double.Parse(Console.ReadLine());

        double biggerNumber = Math.Max(a, b);

        Console.WriteLine("The bigger number is: " + biggerNumber);
    }
}

