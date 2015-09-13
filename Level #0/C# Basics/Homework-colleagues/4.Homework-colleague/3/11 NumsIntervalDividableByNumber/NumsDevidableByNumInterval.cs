/*Write a program that reads two positive integer numbers and prints 
 how many numbers p exist between them such that the reminder of the division by 5 is 0.*/

using System;

class NumsDevidableByNumInterval
{
    static void Main(string[] args)
    {
        Console.Write("Enter the first number of the interval (positive number): ");
        int startNum = int.Parse(Console.ReadLine());

        Console.Write("Enter the last number of the interval (positive number): ");
        int endNum = int.Parse(Console.ReadLine());

        string numByFive = String.Empty;

        for (int i = startNum; i <= endNum; i++)
        {
            if (i % 5 == 0)
            {
                numByFive += i + ", ";
            }
        }
        numByFive = numByFive.Trim();   // Remove the last ' ' from the string
        numByFive = numByFive.TrimEnd(',');     //Remove the ',' from the string
        
        Console.WriteLine(numByFive);
    }
}
