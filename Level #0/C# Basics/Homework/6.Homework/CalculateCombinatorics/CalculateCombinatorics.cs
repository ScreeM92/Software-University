using System;
using System.Numerics;
    class CalculateCombinatorics
    {
        static void Main()
        {
            Console.Write("Please, enter a whole number, bigger from 1 for K = ");
            string numberStr = Console.ReadLine();
            int K = int.Parse(numberStr);
            Console.Write("Enter other whole number, bigger from K for N = ");
            numberStr = Console.ReadLine();
            int N = int.Parse(numberStr);
            if (N <= 1 || K >= N || K < 1 || N > 100 || K >= 100)
            {
                Console.WriteLine("Error - Invalid Input !!!");
            }
            else
            {
                BigInteger resultDivisionN = 1;
                for (int i = N; i > K; i--)
                {
                    resultDivisionN *= i;
                }
                BigInteger resultDivisionK = 1;
                for (int i = 1; i <= (N - K); i++)
                {
                    resultDivisionK *= i;
                }
                BigInteger sum = resultDivisionN / resultDivisionK;
                Console.WriteLine("The result of N! / (K! * (N-K)!) = {0}", sum);
            } 
        }
    }

