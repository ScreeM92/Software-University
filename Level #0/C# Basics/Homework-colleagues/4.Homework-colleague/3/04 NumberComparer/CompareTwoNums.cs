/*Write a program that gets two numbers from the console and prints the greater of them. 
Try to implement this without if statements.*/

using System;

class CompareTwoNums
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        float a = float.Parse(Console.ReadLine());

        Console.Write("Enter a second number: ");
        float b = float.Parse(Console.ReadLine());

        bool greaterNum = a > b;

        Console.WriteLine("Greater: {0}", greaterNum? a : b);
    }
}
