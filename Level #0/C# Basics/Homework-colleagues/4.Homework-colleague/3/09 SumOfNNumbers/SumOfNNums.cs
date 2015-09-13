//Write a program that enters a number n and after that enters more n numbers and calculates and prints their sum.

using System;

class SumOfNNums
{
    static void Main(string[] args)
    {
        Console.Write("Enter how many numbers to sum: ");
        int n = int.Parse(Console.ReadLine());
        double sum = 0;

        for (int i = 0; i < n; i++)
        {
            double num = double.Parse(Console.ReadLine());
            sum += num;
        }
        
        Console.WriteLine("The sum of the numbers is {0}", sum);
    }
}
