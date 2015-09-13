﻿using System;
using System.Numerics;

class Fibonacci
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        BigInteger result = Fib(n);
        Console.WriteLine(result);
    }

    private static BigInteger Fib(int n)
    {
        BigInteger firstNum = 0;
        BigInteger secondNum = 1;
        BigInteger nextNum;

        for (int i = 1; i <= n; i++)
        {
            nextNum = firstNum + secondNum;
            firstNum = secondNum;
            secondNum = nextNum;

            if (i == n)
            {
                return nextNum;
            }
        }

        return 0;
    }
}
