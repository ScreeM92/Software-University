using System;

class FibonacciNumbers
{
    static void Main()
    {
        Console.Write("n=");
        int n = int.Parse(Console.ReadLine());
        int fiboTemA = 0;
        int fiboTempB = 1;
        for (int i = 0; i < n; i++)
        {
            Console.Write(fiboTemA + " ");
            int temp = fiboTemA;
            fiboTemA = fiboTempB;
            fiboTempB = temp + fiboTempB;
        }
    }
}
