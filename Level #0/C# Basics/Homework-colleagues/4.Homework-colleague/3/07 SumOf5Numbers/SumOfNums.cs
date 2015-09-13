//Write a program that enters 5 numbers (given in a single line, separated by a space), calculates and prints their sum.

using System;

class SumOfNums
{
    static void Main(string[] args)
    {
        Console.Write("Enter 5 numbers, separated by space: ");
        string numbers = Console.ReadLine();
        
        string currentNum = null;
        double sum = 0;

        for (int i = 0; i < numbers.Length; i++)    
        {
            if (numbers[i] != ' ')
            {
                currentNum += numbers[i].ToString();
            }
            else
            {
                sum += double.Parse(currentNum);
                currentNum = null;
            }

            if (currentNum != null && i + 1 == numbers.Length)
            {
                sum += double.Parse(currentNum);
            }
        }
        
        Console.WriteLine("The sum is: {0}", sum);
    }
}
