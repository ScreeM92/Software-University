using System;
class NumbersNotDivisibleBy3And7
    {
        static void Main()
        {
            Console.WriteLine("Please enter number from 1 to n not divisible by 3 and 7");
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                if ((i % 7 != 0) && (i % 3 != 0))
                {
                    Console.Write(i + " ");
                }
            }        
        }
    }

