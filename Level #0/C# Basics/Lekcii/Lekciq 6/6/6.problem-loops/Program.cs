using System;
using System.Numerics;
    class Program
    {
        static void Main(string[] args)
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
                /* If looked deeply in factorial function formula, we will understand
                 * why is not necessarily calculate N! and K! separately.
                 * N!=N*(N-1)*(N-2)*...*1 and K!=K*(K-1)*(K-2)*...1;
                 * If N>K K! is Subset of N!, that's mean:
                 * N!= N*(N-1)*(N-2)*...*K*(K-1)*(K-2)*...*1;
                 * Division of N! by K! means:
                 * RESULT = N*(N-1)*(N-2)*...(K+1);
                 * Example: What is 7! / 4! = 7 × 6 × 5 = 210;*/

                decimal resultDivision = 1;
                for (int i = numN; i > numK; i--)
                {
                    resultDivision *= i;
                }
                Console.WriteLine("The Result from Division of N! by K! is RESULT = " + resultDivision);
            }
        }
    }

