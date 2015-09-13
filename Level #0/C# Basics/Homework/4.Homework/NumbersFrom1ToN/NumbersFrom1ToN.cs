using System;
    class NumbersFrom1ToN
    {
        static void Main()
        {
            Console.BufferHeight = 30000;
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i);
            }
        }
    }

