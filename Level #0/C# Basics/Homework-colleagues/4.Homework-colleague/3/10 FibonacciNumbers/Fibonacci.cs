/*Write a program that reads a number n and prints on the console the first n members of the Fibonacci sequence 
(at a single line, separated by spaces):
0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, …. */

using System;

class Fibonacci
{
    static void Main(string[] args)
    {
        Console.Write("Enter the lenght of the Fibonacci sequence: ");
        int n = int.Parse(Console.ReadLine());

        int fibonacciFirst = 0;
        int fibonacciSecond = 1;
        int fibonacciNext = 1;

        for (int i = 0; i < n; i++)
        {
            Console.Write(fibonacciFirst + " ");
            fibonacciNext = fibonacciFirst + fibonacciSecond;
            fibonacciFirst = fibonacciSecond;
            fibonacciSecond = fibonacciNext;
        }

        Console.WriteLine();
    }
}
