using System;
    class Program
    {
        static void Main()
        {
            //N!/X^n
            Console.Write("N!:");
            int n = int.Parse(Console.ReadLine());
            Console.Write("X:");
            int x = int.Parse(Console.ReadLine());
            int nFactorial = 1;
            for (int i = n; i >= 1; i--)
            {
                nFactorial *= i;
            }
            Console.WriteLine(nFactorial);
            int xSum = 1;
            for (int i = 0; i < n; i++)
            {
                xSum *= x;
            }
            Console.WriteLine(xSum);
            Console.WriteLine("{0:F5}", nFactorial/xSum);
        }
    }

