/*Write a program that reads an integer number n from the console 
and prints all the numbers in the interval [1..n], each on a single line.*/

using System;

class NumsToN
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());

        for (int i = 1; i <= num; i++)
        {
            Console.WriteLine(i);
        }
    }
}
