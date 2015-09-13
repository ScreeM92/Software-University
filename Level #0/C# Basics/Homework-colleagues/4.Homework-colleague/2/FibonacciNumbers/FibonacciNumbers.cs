using System;

class FibonacciNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        ulong a1 = 0;
        ulong a2 = 1;
        ulong a3;
        Console.Write("{0} {1} ", a1, a2);
        for (int i = 1; i <= n - 2; i++)
        {
            a3 = a1 + a2;
            Console.Write("{0} ", a3);
            a1 = a2;
            a2 = a3;
        }
        Console.WriteLine();
    }
}