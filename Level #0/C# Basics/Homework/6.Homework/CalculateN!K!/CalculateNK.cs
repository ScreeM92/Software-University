using System;
using System.Numerics;
    class CalculateNK
    {
        static void Main()
        {
            Console.Write("Please, enter a whole number, bigger from 1 for K = ");
            string numberStr = Console.ReadLine();
            int numK = int.Parse(numberStr);
            Console.Write("Enter other whole number, bigger from K for N = ");
            numberStr = Console.ReadLine();
            int numN = int.Parse(numberStr);
            if (numN <= 1 || numK >= numN || numK < 1 || numN > 100 || numK >= 100)
            {
                Console.WriteLine("Error - Invalid Input !!!");
            }
            else
            {
                BigInteger resultDivision = 1;
                for (int i = numN; i > numK; i--)
                {
                    resultDivision *= i;
                }
                Console.WriteLine("The Result from Division of N! by K! is RESULT = " + resultDivision);
            }
        }
    }

