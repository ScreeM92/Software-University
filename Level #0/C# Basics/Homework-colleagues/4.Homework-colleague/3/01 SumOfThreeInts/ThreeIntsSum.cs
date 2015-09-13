//Write a program that reads 3 integer numbers from the console and prints their sum.

using System;

class ThreeIntsSum
{
    static void Main(string[] args)
    {
        Console.Write("Enter a: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Enter b: ");
        int b = int.Parse(Console.ReadLine());

        Console.Write("Enter c: ");
        int c = int.Parse(Console.ReadLine());

        int sum = a + b + c;

        Console.WriteLine("The sum of {0}, {1} and {2} is {3}", a, b, c, sum);
    }
}
